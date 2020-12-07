using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;

namespace RSPO_UP_6.ViewModel
{
    public class CowViewModel : ViewModelBase
    {
        private readonly object _monitor = new object();
        private ObservableCollection<LiveViewModel> _lives;
        private Func<int, int, MoveDirection, bool> _isBlockOn;
        private int _row, _column;
        private EntitySettingsViewModel _settings;

        public event GoCow CowPositionChanged;

        public int Row 
        { 
            get => _row; 
            set => SetValue(ref _row, value);
        }

        public int Column
        {
            get => _column;
            set => SetValue(ref _column, value);
        }

        public ObservableCollection<LiveViewModel> Lives
        {
            get => _lives;
            set => SetValue(ref _lives, value);
        }

        public EntitySettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        public async Task MoveUp()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (_isBlockOn(Row, Column, MoveDirection.Up)) return;
                Row--;
                CowPositionChanged?.Invoke(MoveDirection.Up);
            }
        }

        public async Task MoveDown()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (_isBlockOn(Row, Column, MoveDirection.Down)) return;
                Row++;
                CowPositionChanged?.Invoke(MoveDirection.Down);
            }
        }

        public async Task MoveRight()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (_isBlockOn(Row, Column, MoveDirection.Right)) return;
                Column++;
                CowPositionChanged?.Invoke(MoveDirection.Right);
            }
        }

        public async Task MoveLeft()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (_isBlockOn(Row, Column, MoveDirection.Left)) return;
                Column--;
                CowPositionChanged?.Invoke(MoveDirection.Left);
            }
        }

        public CowViewModel(Func<int, int, MoveDirection, bool> isBlockOn)
        {
            _isBlockOn = isBlockOn;
            Lives = new ObservableCollection<LiveViewModel>()
            {
                new LiveViewModel(),
                new LiveViewModel(),
                new LiveViewModel()
            };
            Settings = new EntitySettingsViewModel
            {
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\cow.gif"
            };
        }
    }
}
