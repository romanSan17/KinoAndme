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
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void adminA_Click(object sender, EventArgs e)
        {
            AdminLog adminLogForm = new AdminLog();
            adminLogForm.Show();
        }

        private void kasutajaR_Click(object sender, EventArgs e)
        {
            KasutajaReg KasutajaRForm = new KasutajaReg();
            KasutajaRForm.Show();
        }

        private void kasutajaA_Click(object sender, EventArgs e)
        {
            KasutajaLog KasutajaLForm = new KasutajaLog();
            KasutajaLForm.Show();
        }
    }
}
