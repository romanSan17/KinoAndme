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
    public partial class KasutajaLog : Form
    {
        public KasutajaLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFilm ChooseFilmForm = new ChooseFilm();
            ChooseFilmForm.Show();
        }
    }
}
