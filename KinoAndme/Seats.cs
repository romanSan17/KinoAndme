using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace KinoAndme
{
    public partial class Seats : Form
    {
        // Список для хранения выбранных мест
        private List<string> selectedSeats = new List<string>();

        // Подключение к базе данных
        private string connectionString = "your_connection_string"; // Поменяй на свою строку подключения

        public Seats()
        {
            InitializeComponent();

            // Подключаем обработчик для всех кнопок
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name.StartsWith("button"))
                {
                    button.Click += SeatButton_Click;
                }
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            // Получаем кнопку, на которую нажали
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                string seatNumber = clickedButton.Text;

                // Проверка, занято ли место
                if (!IsSeatBooked(seatNumber))
                {
                    if (!selectedSeats.Contains(seatNumber))
                    {
                        // Добавляем место в список выбранных и меняем цвет кнопки
                        selectedSeats.Add(seatNumber);
                        clickedButton.BackColor = System.Drawing.Color.Green; // Место выбрано
                    }
                    else
                    {
                        // Убираем место из списка выбранных и возвращаем цвет кнопки
                        selectedSeats.Remove(seatNumber);
                        clickedButton.BackColor = System.Drawing.Color.LightGray; // Место отменено
                    }
                }
                else
                {
                    MessageBox.Show($"Место {seatNumber} уже забронировано.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void confirmButton_Click_1(object sender, EventArgs e)
        {
            // Проверяем, выбраны ли места
            if (selectedSeats.Count > 0)
            {
                // Пытаемся забронировать места
                if (BookSelectedSeats())
                {
                    MessageBox.Show("Вы успешно забронировали места: " + string.Join(", ", selectedSeats), "Бронирование");
                    this.Close(); // Закрываем форму после бронирования
                }
                else
                {
                    MessageBox.Show("Ошибка при бронировании мест. Возможно, некоторые места уже забронированы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите хотя бы одно место!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsSeatBooked(string seatNumber)
        {
            try
            {
                // Правильная строка подключения
                string connectionString = "Server=localhost;Database=YourDatabase;User Id=YourUsername;Password=YourPassword;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Kohad WHERE koha_number = @seatNumber AND status = 'booked'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@seatNumber", seatNumber);

                    connection.Open(); // Открываем соединение
                    int bookedCount = (int)cmd.ExecuteScalar(); // Получаем количество занятых мест

                    return bookedCount > 0; // Возвращаем true, если место забронировано
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool BookSelectedSeats()
        {
            // Бронируем все выбранные места в базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (string seatNumber in selectedSeats)
                    {
                        // Обновляем статус на "booked" только для мест, которые свободны
                        string query = "UPDATE Kohad SET status = 'booked' WHERE koha_number = @seatNumber AND status = 'free'";
                        SqlCommand cmd = new SqlCommand(query, connection, transaction);
                        cmd.Parameters.AddWithValue("@seatNumber", seatNumber);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Если место уже занято, откатываем транзакцию
                        if (rowsAffected == 0)
                        {
                            transaction.Rollback();
                            return false; // Не удалось забронировать, место уже занято
                        }
                    }

                    // Подтверждаем транзакцию
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    // Откатываем транзакцию в случае ошибки
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
