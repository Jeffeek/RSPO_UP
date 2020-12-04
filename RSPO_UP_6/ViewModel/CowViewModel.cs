using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using RSPO_UP_6.Model.Controllers;
using RSPO_UP_6.Model.Entities;

namespace RSPO_UP_6.ViewModel
{
    public class CowViewModel : ViewModelBase
    {
        private string _currentImageSource;
        public event GoCow CowPositionChanged;
        public Cow Cow { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Size { get; set; }

        public CowViewModel()
        {
            
        }

        private void CowController_CowPositionChanged(MoveDirection direction)
        {
            throw new NotImplementedException();
        }

        public string ImageSource
        {
            get => _currentImageSource;
            set => SetValue(ref _currentImageSource, value);
        }

        public async Task MoveUp()
        {
            await Task.Delay(Cow.Settings.Delay);
            if (Row == 0) return;
            Row--;
            CowPositionChanged?.Invoke(MoveDirection.Up);
        }

        public async Task MoveDown()
        {
            if (Size - 1 == Row) return;
            await Task.Delay(Cow.Settings.Delay);
            Row++;
            CowPositionChanged?.Invoke(MoveDirection.Down);
        }

        public async Task MoveRight()
        {
            if (Size - 1 == Row) return;
            await Task.Delay(Cow.Settings.Delay);
            Column++;
            CowPositionChanged?.Invoke(MoveDirection.Right);
        }

        public async Task MoveLeft()
        {
            if (Size - 1 == Column) return;
            await Task.Delay(Cow.Settings.Delay);
            Row++;
            CowPositionChanged?.Invoke(MoveDirection.Down);
        }
    }
}
