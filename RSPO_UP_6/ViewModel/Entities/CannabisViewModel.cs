using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RSPO_UP_6.Model.Controllers;
using RSPO_UP_6.ViewModel.Entities;

namespace RSPO_UP_6.ViewModel
{
    public class CannabisViewModel : ViewModelBase
    {
        #region Events

        public event EntityMovedTo CannabisPositionChanged;
        public event EventHandler CannabisCollected;

        #endregion

        #region Fields

        private Func<int, int, bool> _isCellFree;
        private readonly Random _randomCannabis = new Random(DateTime.Now.Millisecond * DateTime.Now.Second / 2 * DateTime.MinValue.Second);
        private EntitySettingsViewModel _settings;
        private int _currentRow = 0, _currentColumn = 0;
        private bool _isCollected;
        private bool _isGameStopped;

        #endregion

        #region Properties

        public bool IsGameStopped
        {
            get => _isGameStopped;
            set => SetValue(ref _isGameStopped, value);
        }

        public bool IsCollected
        {
            get => _isCollected;
            set
            {
                if (value)
                    CannabisCollected?.Invoke(this, EventArgs.Empty);
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

        #endregion

        public CannabisViewModel(Func<int, int, bool> isCellFree)
        {
            _isCellFree = isCellFree;
            Settings = new EntitySettingsViewModel()
            {
                Delay = 2000,
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\cannabis.png"
            };
        }

        public void Start()
        {
            SpawnCannabis();
        }

        private async Task SpawnCannabis()
        {
            await Task.Delay(Settings.Delay / 2);
            IsCollected = false;
            if (IsGameStopped)
            {
                Row = 0;
                Column = 0;
                return;
            }
            int row = _randomCannabis.Next(0, 10);
            int column = _randomCannabis.Next(0, 10);
            while (!_isCellFree(row, column))
            {
                row = _randomCannabis.Next(0, 10);
                column = _randomCannabis.Next(0, 10);
            }
            Row = row;
            Column = column;
            CannabisPositionChanged?.Invoke(Row, Column);
            RemoveCannabis();
        }

        private async Task RemoveCannabis()
        {
            await Task.Delay(Settings.Delay / 2);
            if (!IsGameStopped)
                SpawnCannabis();
        }
    }
}
