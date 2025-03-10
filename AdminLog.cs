using KinoAndme.KinoDataSetTableAdapters;
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
    public partial class AdminLog : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Kino;Integrated Security=True;";

        public AdminLog()
        {
            InitializeComponent();
        }

        private void adminAutoris_Click(object sender, EventArgs e)
        {
            string login = loginA.Text.Trim();
            string password = paroolA.Text.Trim();

            try
            {
                if (CheckUserLogin(login, password))
                {
                    string role = GetUserRole(login);

                    if (role == "admin")
                    {
                        MessageBox.Show("Tere tulemast, admin!");
                        AdminPanel adminPanel = new AdminPanel();
                        adminPanel.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Juurdepääs on lubatud ainult administraatorile.");
                    }
                }
                else
                {
                    MessageBox.Show("Vale sisselogimine või salasõna.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Viga: {ex.Message}");
            }
        }

        private bool CheckUserLogin(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Kasutaja WHERE login = @login AND parool = @password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());

                return result > 0;
            }
        }

        private string GetUserRole(string login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT roll FROM Kasutaja WHERE login = @login";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@login", login);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return result?.ToString();
            }
        }
    }
}