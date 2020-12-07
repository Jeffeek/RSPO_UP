using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace RSPO_UP_6.ViewModel
{
    public class BombViewModel : ViewModelBase
    {
        private Random _randomBomb = new Random(DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.UtcNow.Millisecond / 2);
        private int _currentRow = 0, _currentColumn = 0;
        private List<(int, int)> _freeCells;
        private EntitySettingsViewModel _settings;
        private bool _isExploded;

        public event EventHandler<bool> BombStateChanged;

        public bool IsExploded
        {
            get => _isExploded;
            private set
            {
                _isExploded = value;
                BombStateChanged?.Invoke(this, _isExploded);
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

        public BombViewModel(List<(int, int)> freeCells)
        {
            _freeCells = freeCells;
            Settings = new EntitySettingsViewModel()
            {
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\bomb.png",
                Delay = 3000
            };
            SpawnBomb();
        }

        private async Task SpawnBomb()
        {
            Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\bomb.png";
            IsExploded = false;
            int placeToPaste = _randomBomb.Next(0, _freeCells.Count);
            Row = _freeCells[placeToPaste].Item1;
            Column = _freeCells[placeToPaste].Item2;
            await BombExplode();
        }

        private async Task BombExplode()
        {
            await Task.Delay(Settings.Delay / 2);
            Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\explosion.png";
            IsExploded = true;
            await Task.Delay(Settings.Delay / 2);
            Row = 0;
            Column = 0;
            SpawnBomb();
        }
    }
}
