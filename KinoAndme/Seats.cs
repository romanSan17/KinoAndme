using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KinoAndme
{
    public partial class Seats : Form
    {
        private int filmID;
        private int sessionID;
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Kino;Integrated Security=True;Connect Timeout=30;";
        private List<int> selectedSeats = new List<int>();

        public Seats(int filmID, int sessionID)
        {
            InitializeComponent();
            this.filmID = filmID;
            this.sessionID = sessionID;
            LoadSeatsData();
        }

        private void LoadSeatsData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT kohID, rida, koha_number, status 
                    FROM Kohad 
                    WHERE Saalid_saaID IN (
                        SELECT Saalid_saaID 
                        FROM Seansid 
                        WHERE Filmid_filID = @filmID AND seaID = @sessionID
                    )";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@filmID", filmID);
                    cmd.Parameters.AddWithValue("@sessionID", sessionID);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int kohID = reader.GetInt32(0);
                        int rida = reader.GetInt32(1);
                        int kohaNumber = reader.GetInt32(2);
                        string status = reader.GetString(3);

                        Button seatButton = this.Controls.Find($"button{kohaNumber}", true).FirstOrDefault() as Button;

                        if (seatButton != null)
                        {
                            seatButton.Tag = kohID;
                            seatButton.BackColor = status == "free" ? Color.LightGray : Color.Red;
                            seatButton.Enabled = status == "free";
                            seatButton.Click += SeatButton_Click;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке мест: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button seatButton = sender as Button;
            if (seatButton == null) return;

            int kohID = (int)seatButton.Tag;

            if (selectedSeats.Contains(kohID))
            {
                selectedSeats.Remove(kohID);
                seatButton.BackColor = Color.LightGray;
            }
            else
            {
                selectedSeats.Add(kohID);
                seatButton.BackColor = Color.Green;
            }
        }

        private void confirmButton_Click_1(object sender, EventArgs e)
        {
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одно место!");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        foreach (int seatID in selectedSeats)
                        {
                            string query = "UPDATE Kohad SET status = 'booked' WHERE kohID = @kohID";
                            SqlCommand cmd = new SqlCommand(query, connection, transaction);
                            cmd.Parameters.AddWithValue("@kohID", seatID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Места успешно забронированы!");
                        LoadSeatsData();
                    }
                    catch
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ошибка при бронировании мест.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Создаём экземпляр ChooseFilm и показываем его
            ChooseFilm chooseFilmForm = new ChooseFilm();
            chooseFilmForm.Show();
        }
    }
}
