using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using RSPO_UP_6.Model.Entities;

namespace RSPO_UP_6.ViewModel
{
    public class BombViewModel : ViewModelBase
    {
        private int _currentRow, _currentColumn;

        public Bomb Bomb { get; private set; }

        public BombViewModel()
        {
            Bomb = new Bomb();
        }



        public async Task Explode()
        {
            await Task.Delay(Bomb.Settings.Delay);
            Bomb.Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\explosion.png";
            Bomb.Settings.Image = new Image { Source = new BitmapImage(new Uri(Bomb.Settings.ImagePath)) };
        }
    }
}
