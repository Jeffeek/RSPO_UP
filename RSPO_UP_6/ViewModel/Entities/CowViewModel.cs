using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;

namespace RSPO_UP_6.ViewModel.Entities
{
    public class CowViewModel : ViewModelBase
    {
        #region Events

        public event EntityMovedTo CowPositionChanged;
        public event EntityToMoveDirection CowWantsToChangePosition;
        public event CowMovedInDirection CowMovedTo;

        #endregion

        #region Fields

        private readonly object _monitor = new object();
        private ObservableCollection<LiveViewModel> _lives;
        private Func<int, int, bool> _isCellFree;
        private int _row = 0, _column = 0;
        private EntitySettingsViewModel _settings;

        #endregion

        #region Properties

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

        #endregion

        #region Controller

        public async Task MoveUp()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                CowWantsToChangePosition?.Invoke(Row, Column, MoveDirection.Up);
                if (_isCellFree(Row - 1, Column)) return;
                Row--;
                CowPositionChanged?.Invoke(Row, Column);
                CowMovedTo?.Invoke(MoveDirection.Up);
            }
        }

        public async Task MoveDown()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                CowWantsToChangePosition?.Invoke(Row, Column, MoveDirection.Down);
                if (_isCellFree(Row + 1, Column)) return;
                Row++;
                CowPositionChanged?.Invoke(Row, Column);
                CowMovedTo?.Invoke(MoveDirection.Down);
            }
        }

        public async Task MoveRight()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                CowWantsToChangePosition?.Invoke(Row, Column, MoveDirection.Right);
                if (_isCellFree(Row, Column + 1)) return;
                Column++;
                CowPositionChanged?.Invoke(Row, Column);
                CowMovedTo?.Invoke(MoveDirection.Right);
            }
        }

        public async Task MoveLeft()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                CowWantsToChangePosition?.Invoke(Row, Column, MoveDirection.Left);
                if (_isCellFree(Row, Column - 1)) return;
                Column--;
                CowPositionChanged?.Invoke(Row, Column);
                CowMovedTo?.Invoke(MoveDirection.Left);
            }
        }

        #endregion

        public CowViewModel(Func<int, int, bool> isCellFree)
        {
            _isCellFree = isCellFree;
            Lives = new ObservableCollection<LiveViewModel>()
            {
                new LiveViewModel(),
                new LiveViewModel(),
                new LiveViewModel()
            };
            Settings = new EntitySettingsViewModel
            {
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\cow.gif",
                Delay = 0
            };
        }
    }
}
