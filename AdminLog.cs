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
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Kino;Integrated Security=True;Connect Timeout=30;";

        public AdminLog()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void adminAutoris_Click(object sender, EventArgs e)
        {
            string login = loginA.Text.Trim();
            string password = paroolA.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Palun täitke kõik väljad!", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Kasutaja WHERE logi = @login AND parool = @password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private string GetUserRole(string login)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT rool FROM Kasutaja WHERE logi = @login";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }
    }
}