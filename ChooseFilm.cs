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
        private int currentImageIndex = 0;

        // Указываем правильный относительный путь к изображениям
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
            UpdatePoster();  // Загружаем первое изображение при старте
        }

        private void forward_Click(object sender, EventArgs e)
        {
            currentImageIndex++;
            if (currentImageIndex >= filmPosters.Length) currentImageIndex = 0;  // Перелистывание, если индекс выходит за пределы
            UpdatePoster();  // Обновляем изображение
        }

        private void back_Click(object sender, EventArgs e)
        {
            currentImageIndex--;
            if (currentImageIndex < 0) currentImageIndex = filmPosters.Length - 1;  // Если индекс отрицательный, возвращаем на последний постер
            UpdatePoster();  // Обновляем изображение
        }

        // Метод для обновления изображения в pictureBox
        private void UpdatePoster()
        {
            try
            {
                // Загружаем изображение из файла по текущему индексу
                pictureBox1.Image = Image.FromFile(filmPosters[currentImageIndex]);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Изображение не найдено. Проверьте путь к файлам.");
            }
        }
    }
}