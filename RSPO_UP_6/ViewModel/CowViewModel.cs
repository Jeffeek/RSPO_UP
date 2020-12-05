using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;
using RSPO_UP_6.Model.Entities;

namespace RSPO_UP_6.ViewModel
{
    public class CowViewModel : ViewModelBase
    {
        private readonly object _monitor = new object();
        private string _currentImageSource;
        private int _row, _column;
        public Cow Cow { get; set; }
        public int Size { get; set; }

        public event GoCow CowPositionChanged;
        public int Row { get => _row; set => SetValue(ref _row, value); }
        public int Column { get => _column; set => SetValue(ref _column, value); }

        public ObservableCollection<bool> Lives { get; set; }

        public CowViewModel()
        {
            Cow = new Cow {Settings = new EntitySettings {Delay = 5}};
            Lives = new ObservableCollection<bool>() {true, true, true};
        }

        public string ImageSource
        {
            get => _currentImageSource;
            set => SetValue(ref _currentImageSource, value);
        }

        public async Task MoveUp()
        {
            await Task.Delay(Cow.Settings.Delay);
            lock (_monitor)
            {
                if (Row == 0) return;
                Row--;
                CowPositionChanged?.Invoke(MoveDirection.Up);
            }
        }

        public async Task MoveDown()
        {
            await Task.Delay(Cow.Settings.Delay);
            lock (_monitor)
            {
                if (Size - 1 == Row) return;
                Row++;
                CowPositionChanged?.Invoke(MoveDirection.Down);
            }
        }

        public async Task MoveRight()
        {
            await Task.Delay(Cow.Settings.Delay);
            lock (_monitor)
            {
                if (Size - 1 == Column) return;
                Column++;
                CowPositionChanged?.Invoke(MoveDirection.Right);
            }
        }

        public async Task MoveLeft()
        {
            await Task.Delay(Cow.Settings.Delay);
            lock (_monitor)
            {
                if (Column == 0) return;
                Column--;
                CowPositionChanged?.Invoke(MoveDirection.Down);
            }
        }
    }
}
