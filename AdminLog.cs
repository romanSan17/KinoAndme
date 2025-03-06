﻿using KinoAndme.KinoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoAndme
{
    public partial class AdminLog : Form
    {
        private KinoDataSetTableAdapters.KasutajaTableAdapter kasutajaTableAdapter = new KinoDataSetTableAdapters.KasutajaTableAdapter();
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

            try
            {
                var result = Convert.ToInt32(kasutajaTableAdapter.CheckUserLogin(login, password));

                if (result > 0)
                {
                    string role = kasutajaTableAdapter.GetUserRole(login)?.ToString();

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
    }
}