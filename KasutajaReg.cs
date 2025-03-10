﻿using System;
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
    public partial class KasutajaReg : Form
    {
        private KinoDataSetTableAdapters.KasutajaTableAdapter kasutajaAdapter = new KinoDataSetTableAdapters.KasutajaTableAdapter();
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

            try
            {
                kasutajaAdapter.InsertKasutaja(nimi, logi, parool, rool);
                MessageBox.Show("Registreerimine oli edukas!", "Edu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nimiR.Clear();
                loginR.Clear();
                paroolR.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registreerimisviga: {ex.Message}", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
