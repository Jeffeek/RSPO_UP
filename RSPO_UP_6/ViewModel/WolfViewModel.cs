using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;

namespace RSPO_UP_6.ViewModel
{
    public class WolfViewModel : ViewModelBase
    {
        private readonly object _monitor = new object();
        private EntitySettingsViewModel _settings;
        private ObservableCollection<BrickViewModel> _bricks;
        private int _row, _column;
        public int Size { get; set; }

        public ObservableCollection<BrickViewModel> Bricks
        {
            get => _bricks;
            set => SetValue(ref _bricks, value);
        }

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

        public void CowMovedExecuted(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Down:
                {
                    MoveUp();
                    break;
                }
                case MoveDirection.Up:
                {
                    MoveDown();
                    break;
                }
                case MoveDirection.Left:
                {
                    MoveRight();
                    break;
                }
                case MoveDirection.Right:
                {
                    MoveLeft();
                    break;
                }
            }
        }

        public async Task MoveRight()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (Size - 1 == Column || 
                    Bricks.SingleOrDefault(x => x.Row == Row && x.Column == Column + 1) != null)
                    return;
                Column++;
            }
        }

        public async Task MoveLeft()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (Column == 0 ||
                    Bricks.SingleOrDefault(x => x.Row == Row && x.Column == Column - 1) != null) 
                    return;
                Column--;
            }
        }

        public async Task MoveDown()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (Size - 1 == Row ||
                    Bricks.SingleOrDefault(x => x.Column == Column && x.Row == Row + 1) != null) 
                    return;
                Row++;
            }
        }

        public async Task MoveUp()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (Row == 0 ||
                    Bricks.SingleOrDefault(x => x.Column == Column && x.Row == Row - 1) != null) 
                    return;
                Row--;
            }
        }

        public WolfViewModel()
        {
            Settings = new EntitySettingsViewModel();
            Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\wolf.png";
        }
    }
}
