using KinoAndme.KinoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoAndme
{
    public partial class ChooseFilm : Form
    {
        
        private int currentFilmIndex = 0;
        private KinoDataSet.FilmidDataTable filmidTable;
        private FilmidTableAdapter filmidAdapter = new FilmidTableAdapter();

        private string[] filmPosters =
        {
            @"poster\It.jpg",
            @"poster\Pulp-fiction.jpg",
            @"poster\Godzilla.jpg",
            @"poster\Spider-man.jpg"
        };

        public ChooseFilm()
        {
            InitializeComponent();
            LoadFilmData(); 
            UpdateFilmInfo(); 
        }
        private void LoadFilmData()
        {
            try
            {
                filmidTable = filmidAdapter.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void UpdateFilmInfo()
        {
            if (filmidTable == null || filmidTable.Rows.Count == 0)
            {
                MessageBox.Show("Данные о фильмах отсутствуют.");
                return;
            }

            var currentFilm = filmidTable[currentFilmIndex];


            labelPealkiri.Text = $"Название: {currentFilm.pealkiri}";
            labelZanr.Text = $"Жанр: {currentFilm.zanr}";
            labelAeg.Text = $"Время сеанса: {currentFilm.aeg}";


            try
            {
                pictureBox1.Image = Image.FromFile($@"poster\{currentFilm.pealkiri}.jpg");
            }
            catch (FileNotFoundException)
            {
                pictureBox1.Image = null;
                MessageBox.Show($"Постер для фильма '{currentFilm.pealkiri}' не найден.");
            }
        }


        private void forward_Click(object sender, EventArgs e)
        {
            currentFilmIndex++;
            if (currentFilmIndex >= filmidTable.Rows.Count) currentFilmIndex = 0;
            UpdateFilmInfo();
        }

        private void back_Click(object sender, EventArgs e)
        {
            currentFilmIndex--;
            if (currentFilmIndex < 0) currentFilmIndex = filmidTable.Rows.Count - 1;
            UpdateFilmInfo();
        }


    }
}