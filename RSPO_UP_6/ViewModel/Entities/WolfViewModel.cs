using System;
using System.IO;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;

namespace RSPO_UP_6.ViewModel.Entities
{
    public class WolfViewModel : ViewModelBase
    {
        #region Events

        public event EntityMovedTo WolfPositionChanged;
        public event EntityToMoveDirection WolfWantsToChangePosition;

        #endregion

        #region Fields

        private readonly object _monitor = new object();
        private Func<int, int, bool> _isCellFree;
        private EntitySettingsViewModel _settings;
        private int _row, _column;

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

        public EntitySettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        #endregion

        public async Task CowMovedEventHandler(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Down:
                {
                    await MoveUp();
                    break;
                }
                case MoveDirection.Up:
                {
                    await MoveDown();
                    break;
                }
                case MoveDirection.Left:
                {
                    await MoveRight();
                    break;
                }
                case MoveDirection.Right:
                {
                    await MoveLeft();
                    break;
                }
                case MoveDirection.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        #region Controller

        public async Task MoveRight()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                WolfWantsToChangePosition?.Invoke(Row, Column, MoveDirection.Right);
                if (!_isCellFree(Row, Column + 1)) return;
                Column++;
                WolfPositionChanged?.Invoke(Row, Column);
            }
        }

        public async Task MoveLeft()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                WolfWantsToChangePosition?.Invoke(Row, Column, MoveDirection.Left);
                if (!_isCellFree(Row, Column - 1)) return;
                Column--;
                WolfPositionChanged?.Invoke(Row, Column);
            }
        }

        public async Task MoveDown()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                WolfWantsToChangePosition?.Invoke(Row, Column, MoveDirection.Down);
                if (!_isCellFree(Row + 1, Column)) return;
                Row++;
                WolfPositionChanged?.Invoke(Row, Column);
            }
        }

        public async Task MoveUp()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                WolfWantsToChangePosition?.Invoke(Row, Column, MoveDirection.Down);
                if (!_isCellFree(Row - 1, Column)) return;
                Row--;
                WolfPositionChanged?.Invoke(Row, Column);
            }
        }

        #endregion

        public WolfViewModel(Func<int, int, bool> isCellFree)
        {
            _isCellFree = isCellFree;
            Settings = new EntitySettingsViewModel
            {
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\wolf.png",
                Delay = 100
            };
        }
    }
}
