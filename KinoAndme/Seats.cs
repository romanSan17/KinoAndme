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
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Kino;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private Dictionary<Button, int> seatButtons = new Dictionary<Button, int>();
        private List<int> selectedSeats = new List<int>();

        public Seats()
        {
            InitializeComponent();
            InitializeSeats();
            LoadSeatStatuses();
        }

        // Инициализация кнопок и их привязка к номерам мест
        private void InitializeSeats()
        {
            seatButtons.Add(button1, 1);
            seatButtons.Add(button2, 2);
            seatButtons.Add(button3, 3);
            seatButtons.Add(button4, 4);
            seatButtons.Add(button5, 5);
            seatButtons.Add(button6, 6);
            seatButtons.Add(button7, 7);
            seatButtons.Add(button8, 8);
            seatButtons.Add(button9, 9);
            seatButtons.Add(button10, 10);
            seatButtons.Add(button11, 11);
            seatButtons.Add(button12, 12);

            foreach (var button in seatButtons.Keys)
            {
                button.Click += SeatButton_Click;
            }
        }

        // Обработчик клика по кнопкам мест
        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            int seatNumber = seatButtons[clickedButton];

            if (selectedSeats.Contains(seatNumber))
            {
                selectedSeats.Remove(seatNumber);
                clickedButton.BackColor = Color.LightGray; // Вернуть цвет в изначальное состояние
            }
            else
            {
                selectedSeats.Add(seatNumber);
                clickedButton.BackColor = Color.LightBlue; // Выделить место
            }
        }

        // Загрузка статусов мест из базы данных
        private void LoadSeatStatuses()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT koha_number, status FROM Kohad";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int seatNumber = reader.GetInt32(0);
                    string status = reader.GetString(1);

                    foreach (var pair in seatButtons)
                    {
                        if (pair.Value == seatNumber)
                        {
                            if (status == "occupied")
                            {
                                pair.Key.BackColor = Color.Red; // Занятое место
                                pair.Key.Enabled = false; // Отключить кнопку
                            }
                            else
                            {
                                pair.Key.BackColor = Color.LightGray; // Свободное место
                            }
                        }
                    }
                }

                reader.Close();
                connection.Close();
            }
        }

        // Обработка нажатия кнопки подтверждения
        private void confirmButton_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (int seatNumber in selectedSeats)
                {
                    string query = "UPDATE Kohad SET status = 'occupied' WHERE koha_number = @koha_number";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@koha_number", seatNumber);
                    command.ExecuteNonQuery();

                    // Обновить состояние кнопок
                    foreach (var pair in seatButtons)
                    {
                        if (pair.Value == seatNumber)
                        {
                            pair.Key.BackColor = Color.Red; // Пометить занятым
                            pair.Key.Enabled = false; // Отключить кнопку
                        }
                    }
                }

                selectedSeats.Clear(); // Очистить выбор
                MessageBox.Show("Места успешно забронированы!");
            }
        }
    }
}