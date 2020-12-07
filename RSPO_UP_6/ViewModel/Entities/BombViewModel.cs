using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RSPO_UP_6.ViewModel
{
    public class BombViewModel : ViewModelBase
    {
        private int _currentRow, _currentColumn, _size;
        private EntitySettingsViewModel _settings;

        public int Size
        {
            get => _size;
            set => SetValue(ref _size, value);
        }

        public int Row
        {
            get => _currentRow;
            set => SetValue(ref _currentRow, value);
        }

        public int Column
        {
            get => _currentColumn;
            set => SetValue(ref _currentColumn, value);
        }

        public EntitySettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        public async Task Explode()
        {
            await Task.Delay(Settings.Delay);
            Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\explosion.png";
        }

        public BombViewModel()
        {
            Settings = new EntitySettingsViewModel();
        }
    }
}
