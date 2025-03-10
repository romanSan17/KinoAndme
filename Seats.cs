using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;


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
            WHERE Seansid_seaID = @sessionID"; // Фильтруем места по сеансу

                    SqlCommand cmd = new SqlCommand(query, connection);
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
                MessageBox.Show("Viga seats: " + ex.Message, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Valige vähemalt üks koht\r\n!");
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
                        // Обновление статуса мест в транзакции
                        foreach (int seatID in selectedSeats)
                        {
                            string query = "UPDATE Kohad SET status = 'booked' WHERE kohID = @kohID";
                            SqlCommand cmd = new SqlCommand(query, connection, transaction);
                            cmd.Parameters.AddWithValue("@kohID", seatID);
                            cmd.ExecuteNonQuery();
                        }

                        // Завершение транзакции
                        transaction.Commit();
                        MessageBox.Show("Kohad on edukalt broneeritud!");

                        // Генерация PDF-билета
                        string movieTitle = GetMovieTitle(filmID);
                        int seatRow = GetSeatRow(selectedSeats.First());
                        int seatNumber = GetSeatNumber(selectedSeats.First());
                        DateTime sessionTime = GetSessionTime(sessionID);

                        GeneratePDF(movieTitle, seatRow, seatNumber, sessionTime);

                        LoadSeatsData(); // Обновить отображение мест после бронирования
                    }
                    catch (Exception ex)
                    {
                        // Откат транзакции в случае ошибки
                        transaction.Rollback();
                        MessageBox.Show("Broneerimisviga: " + ex.Message, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Andmebaasiühenduse viga: " + ex.Message, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetMovieTitle(int filmID)
        {
            string movieTitle = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT pealkiri FROM Filmid WHERE filID = @filmID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@filmID", filmID);
                movieTitle = cmd.ExecuteScalar()?.ToString() ?? "Tundmatu film";
            }
            return movieTitle;
        }

        private int GetSeatRow(int seatID)
        {
            int seatRow = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT rida FROM Kohad WHERE kohID = @seatID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@seatID", seatID);
                seatRow = (int)cmd.ExecuteScalar();
            }
            return seatRow;
        }

        private int GetSeatNumber(int seatID)
        {
            int seatNumber = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT koha_number FROM Kohad WHERE kohID = @seatID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@seatID", seatID);
                seatNumber = (int)cmd.ExecuteScalar();
            }
            return seatNumber;
        }

        private DateTime GetSessionTime(int sessionID)
        {
            DateTime sessionTime = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT aeg FROM Seansid WHERE seaID = @sessionID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@sessionID", sessionID);
                sessionTime = (DateTime)cmd.ExecuteScalar();
            }
            return sessionTime;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChooseFilm chooseFilmForm = new ChooseFilm();
            chooseFilmForm.Show();
        }

        //private void GeneratePDF(string movieTitle, int seatRow, int seatNumber, DateTime sessionTime)
        //{
        //    try
        //    {
        //        // Путь для сохранения билета (на рабочий стол пользователя)
        //        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //        string filePath = Path.Combine(desktopPath, $"Билет_{DateTime.Now:yyyyMMddHHmmss}.pdf");

        //        // Создание документа
        //        Document doc = new Document();
        //        PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

        //        doc.Open();

        //        // Используем iTextSharp.text.Font (избегаем конфликта)
        //        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
        //        iTextSharp.text.Font textFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL);

        //        // Добавляем заголовок
        //        Paragraph title = new Paragraph("Kinopilet.", titleFont);
        //        title.Alignment = Element.ALIGN_CENTER;
        //        doc.Add(title);

        //        doc.Add(new Paragraph("\n")); // Отступ

        //        // Добавляем информацию о билете
        //        doc.Add(new Paragraph($"Film: {movieTitle}", textFont));
        //        doc.Add(new Paragraph($"Seansi aeg {sessionTime:dd.MM.yyyy HH:mm}", textFont));
        //        doc.Add(new Paragraph($"Rida: {seatRow}, Asukoht: {seatNumber}", textFont));

        //        doc.Add(new Paragraph("\nNautige näitust!", textFont));

        //        // Закрываем документ
        //        doc.Close();

        //        // Оповещение пользователя
        //        MessageBox.Show($"Pilet salvestatakse töölauale:\n{filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Viga PDF: {ex.Message}", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
