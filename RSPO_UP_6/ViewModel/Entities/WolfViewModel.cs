using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;

namespace RSPO_UP_6.ViewModel
{
    public class WolfViewModel : ViewModelBase
    {
        private readonly object _monitor = new object();
        private Func<int, int, MoveDirection, bool> _isBlockHere;
        private EntitySettingsViewModel _settings;
        private int _row, _column;

        public event EventHandler WolfPositionChanged;

        public int Row
        {
            get => _row;
            set
            {
                SetValue(ref _row, value);
                WolfPositionChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public int Column
        {
            get => _column;
            set
            {
                SetValue(ref _column, value);
                WolfPositionChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public EntitySettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        public void CowMovedExecuted(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Down:
                {
                    Task.Run(() => MoveUp());
                    break;
                }
                case MoveDirection.Up:
                {
                    Task.Run(() => MoveDown());
                    break;
                }
                case MoveDirection.Left:
                {
                    Task.Run(() => MoveRight());
                    break;
                }
                case MoveDirection.Right:
                {
                    Task.Run(() => MoveLeft());
                    break;
                }
            }
        }

        public async Task MoveRight()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (_isBlockHere(Row, Column, MoveDirection.Right)) return;
                Column++;
            }
        }

        public async Task MoveLeft()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (_isBlockHere(Row, Column, MoveDirection.Left)) return;
                Column--;
            }
        }

        public async Task MoveDown()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (_isBlockHere(Row, Column, MoveDirection.Down)) return;
                Row++;
            }
        }

        public async Task MoveUp()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (_isBlockHere(Row, Column, MoveDirection.Up)) return;
                Row--;
            }
        }

        public WolfViewModel(Func<int, int, MoveDirection, bool> isBlockHere)
        {
            _isBlockHere = isBlockHere;
            Settings = new EntitySettingsViewModel();
            Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\wolf.png";
        }
    }
}
