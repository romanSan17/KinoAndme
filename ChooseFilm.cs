using KinoAndme.KinoDataSetTableAdapters;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KinoAndme
{
    public partial class ChooseFilm : Form
    {
        private int currentFilmIndex = 0;
        private KinoDataSet.FilmidDataTable filmidTable;
        private FilmidTableAdapter filmidAdapter = new FilmidTableAdapter();
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Kino;Integrated Security=True;Connect Timeout=30;";

        public ChooseFilm()
        {
            InitializeComponent();
            LoadFilmData();
            UpdateFilmInfo();
        }

        private void LoadFilmData()
        {
            try
            {
                filmidTable = filmidAdapter.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Viga andmete laadimisel: {ex.Message}");
            }
        }

        private void UpdateFilmInfo()
        {
            if (filmidTable == null || filmidTable.Rows.Count == 0)
            {
                MessageBox.Show("Andmed filmi kohta puuduvad.");
                return;
            }

            var currentFilm = filmidTable[currentFilmIndex];

            labelPealkiri.Text = $"Pealkiri: {currentFilm.pealkiri}";
            labelZanr.Text = $"Žanr: {currentFilm.zanr}";
            labelAeg.Text = $"Seansi aeg: {currentFilm.aeg}";

            try
            {
                pictureBox1.Image = Image.FromFile($@"poster\{currentFilm.pealkiri}.jpg");
            }
            catch (FileNotFoundException)
            {
                pictureBox1.Image = null;
                MessageBox.Show($"Filmi plakat '{currentFilm.pealkiri}' ei leitud.");
            }
        }

        private void forward_Click(object sender, EventArgs e)
        {
            currentFilmIndex = (currentFilmIndex + 1) % filmidTable.Rows.Count;
            UpdateFilmInfo();
        }

        private void back_Click(object sender, EventArgs e)
        {
            currentFilmIndex = (currentFilmIndex - 1 + filmidTable.Rows.Count) % filmidTable.Rows.Count;
            UpdateFilmInfo();
        }

        private int GetSessionID(int filmID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT seaID FROM Seansid WHERE Filmid_filID = @filID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@filID", filmID);

                    connection.Open();
                    object result = cmd.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga seansi vastuvõtmisel " + ex.Message, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currentFilm = filmidTable[currentFilmIndex];
            int selectedFilmID = currentFilm.filID;
            int selectedSessionID = GetSessionID(selectedFilmID);

            if (selectedSessionID == -1)
            {
                MessageBox.Show("Valitud filmi jaoks ei leitud seanssi.");
                return;
            }

            // Открываем форму с местами для выбранного сеанса
            Seats seatsForm = new Seats(selectedFilmID, selectedSessionID);
            seatsForm.Show();
            this.Hide();
        }
    }
}
