using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace KinoAndme
{
    public partial class AdminPanel : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Kino;Integrated Security=True;Connect Timeout=30;";

        public AdminPanel()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadFilmData();
        }

        private void SetupDataGridView()
        {
            dataGridViewMovies.AutoGenerateColumns = false;
            dataGridViewMovies.Columns.Clear();

            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "filID",
                HeaderText = "ID",
                DataPropertyName = "filID",
                Width = 50,
                ReadOnly = true // ID изменять нельзя
            });

            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "pealkiri",
                HeaderText = "pealkiri",
                DataPropertyName = "pealkiri",
                Width = 200
            });

            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "zanr",
                HeaderText = "zanr",
                DataPropertyName = "zanr",
                Width = 150
            });

            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "aeg",
                HeaderText = "seansi aeg",
                DataPropertyName = "aeg",
                Width = 100
            });
        }

        private void LoadFilmData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT filID, pealkiri, zanr, aeg FROM Filmid";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dt);
                    dataGridViewMovies.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Viga andmete laadimisel: {ex.Message}");
                }
            }
        }


        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                string.IsNullOrWhiteSpace(textBoxGenre.Text) ||
                string.IsNullOrWhiteSpace(textBoxTime.Text))
            {
                MessageBox.Show("Täitke kõik väljad!");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Filmid (pealkiri, zanr, aeg) VALUES (@pealkiri, @zanr, @aeg)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pealkiri", textBoxTitle.Text);
                cmd.Parameters.AddWithValue("@zanr", textBoxGenre.Text);
                cmd.Parameters.AddWithValue("@aeg", textBoxTime.Text);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Film on lisatud!");
                    LoadFilmData(); // Перезагружаем список
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lisa viga: {ex.Message}");
                }
            }
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vali kustutatav film");
                return;
            }

            int selectedFilmID = Convert.ToInt32(dataGridViewMovies.SelectedRows[0].Cells["filID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Filmid WHERE filID = @filID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@filID", selectedFilmID);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Film on kustutatud!");
                    LoadFilmData(); // Обновляем список
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kustutamisviga: {ex.Message}");
                }
            }
        }
    }
}
