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
    public partial class KasutajaReg : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Kino;Integrated Security=True;Connect Timeout=30;";

        public KasutajaReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nimi = nimiR.Text;
            string logi = loginR.Text;
            string parool = paroolR.Text;
            string rool = "user";

            if (string.IsNullOrWhiteSpace(nimi) || string.IsNullOrWhiteSpace(logi) || string.IsNullOrWhiteSpace(parool))
            {
                MessageBox.Show("Kõik väljad peavad olema täidetud", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Kasutaja (nimi, logi, parool, rool) VALUES (@nimi, @logi, @parool, @rool)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nimi", nimi);
                        cmd.Parameters.AddWithValue("@logi", logi);
                        cmd.Parameters.AddWithValue("@parool", parool);
                        cmd.Parameters.AddWithValue("@rool", rool);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registreerimine oli edukas!", "Edu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nimiR.Clear();
                            loginR.Clear();
                            paroolR.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Midagi läks valesti, proovige uuesti", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Registreerimisviga: {ex.Message}", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}