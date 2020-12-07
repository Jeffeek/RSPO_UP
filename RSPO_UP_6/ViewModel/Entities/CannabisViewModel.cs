using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RSPO_UP_6.ViewModel
{
    public class CannabisViewModel : ViewModelBase
    {
        private Random _randomCannabis = new Random(DateTime.Now.Millisecond * DateTime.Now.Second / 2 * DateTime.MinValue.Second);
        private List<(int, int)> _freeCells;
        private int _currentRow = 0, _currentColumn = 0;
        private EntitySettingsViewModel _settings;
        private bool _isCollected;

        public event RoutedEventHandler CannabisCollected;

        public bool IsCollected
        {
            get => _isCollected;
            set
            {
                if (value)
                    CannabisCollected?.Invoke(this, new RoutedEventArgs());
                SetValue(ref _isCollected, value);
            }
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

        public CannabisViewModel(List<(int, int)> freeCells)
        {
            _freeCells = freeCells;
            Settings = new EntitySettingsViewModel()
            {
                Delay = 3000,
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\cannabis.png"
            };
            SpawnCannabis();
        }

        private async Task SpawnCannabis()
        {
            await Task.Delay(Settings.Delay / 2);
            int placeToPaste = _randomCannabis.Next(0, _freeCells.Count);
            Row = _freeCells[placeToPaste].Item1;
            Column = _freeCells[placeToPaste].Item2;
            await RemoveCannabis();
        }

        private async Task RemoveCannabis()
        {
            await Task.Delay(Settings.Delay / 2);
            Row = 0;
            Column = 0;
            await SpawnCannabis();
        }
    }
}
