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
        public KasutajaReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFilm ChooseFilmForm1 = new ChooseFilm();
            ChooseFilmForm1.Show();
        }
    }
}
