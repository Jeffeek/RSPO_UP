using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;
using RSPO_UP_6.Model.Entities;

namespace RSPO_UP_6.ViewModel
{
    public class WolfViewModel : ViewModelBase
    {
        private readonly object _monitor = new object();
        private int _row = 0, _column = 9;
        public Wolf Wolf { get; set; }
        public int Size { get; set; } = 10;

        public int Row { get => _row; set => SetValue(ref _row, value); }
        public int Column { get => _column; set => SetValue(ref _column, value); }

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
            await Task.Delay(Wolf.Settings.Delay);
            lock (_monitor)
            {
                if (Size - 1 == Column) return;
                Column++;
            }
        }

        public async Task MoveLeft()
        {
            await Task.Delay(Wolf.Settings.Delay);
            lock (_monitor)
            {
                if (Column == 0) return;
                Column--;
            }
        }

        public async Task MoveDown()
        {
            await Task.Delay(Wolf.Settings.Delay);
            lock (_monitor)
            {
                if (Size - 1 == Row) return;
                Row++;
            }
        }

        public async Task MoveUp()
        {
            await Task.Delay(Wolf.Settings.Delay);
            lock (_monitor)
            {
                if (Row == 0) return;
                Row--;
            }
        }

        public WolfViewModel()
        {
            Wolf = new Wolf();
            Column = Size - 1;
        }
    }
}
