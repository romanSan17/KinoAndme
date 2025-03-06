using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoAndme.KinoDataSetTableAdapters;

namespace KinoAndme

{
    public partial class KasutajaLog : Form
    {
        private KinoDataSetTableAdapters.KasutajaTableAdapter kasutajaTableAdapter = new KinoDataSetTableAdapters.KasutajaTableAdapter();
        public KasutajaLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = loginL.Text;
            string password = paroolL.Text;

            if (IsValidUser(login, password))
            {
                ChooseFilm chooseFilmForm = new ChooseFilm();
                chooseFilmForm.Show();
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Vale sisselogimine või salasõna.");
            }
        }
        private bool IsValidUser(string login, string password)
        {
            try
            {
                var user = this.kasutajaTableAdapter.GetData()
                         .FirstOrDefault(u => u.logi == login && u.parool == password);

                return user != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Andmete valideerimisviga: {ex.Message}");
                return false;
            }
        }
    }
}
