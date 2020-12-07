using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;
using RSPO_UP_6.Model.Map;

namespace RSPO_UP_6.ViewModel
{
    public class MapViewModel : ViewModelBase
    {
        private List<(int, int)> _freeCells;
        private Random _randomBomb = new Random(DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.UtcNow.Millisecond / 2);
        private Random _randomCannabis = new Random(DateTime.Now.Millisecond * DateTime.Now.Second / 2 * DateTime.MinValue.Second);
        private IMap _currentMap;
        private CowViewModel _cow;
        private WolfViewModel _wolf;
        private CannabisViewModel _cannabis;
        private BombViewModel _bomb;
        private ObservableCollection<BrickViewModel> _bricks;

        public event EventHandler<bool> OnGameResult;

        public IMap CurrentMap
        {
            get => _currentMap;
            set => SetValue(ref _currentMap, value);
        }

        public WolfViewModel Wolf
        {
            get => _wolf;
            set => SetValue(ref _wolf, value);
        }

        public CannabisViewModel Cannabis
        {
            get => _cannabis;
            set => SetValue(ref _cannabis, value);
        }

        public BombViewModel Bomb
        {
            get => _bomb;
            set => SetValue(ref _bomb, value);
        }

        public ObservableCollection<BrickViewModel> Bricks
        {
            get => _bricks;
            set => SetValue(ref _bricks, value);
        }

        public CowViewModel Cow
        {
            get => _cow;
            set => SetValue(ref _cow, value);
        }

        public MapViewModel(IMap map)
        {
            Bricks = new ObservableCollection<BrickViewModel>();
            _freeCells = new List<(int, int)>();
            CurrentMap = map;
            Cow = new CowViewModel(IsBlockOn);
            Wolf = new WolfViewModel(IsBlockOn)
            {
                Column = CurrentMap.Size - 1,
                Row = 0
            };
            Cow.CowPositionChanged += Wolf.CowMovedExecuted;
            Cow.CowPositionChanged += RemoveLiveOrWin;
            Bomb = new BombViewModel();
            Cannabis = new CannabisViewModel();
            InitBricks();
            FillFreeCells();
            SpawnBomb();
            SpawnCannabis();
        }

        private void FillFreeCells()
        {
            for (int i = 0; i < CurrentMap.Size; i++)
            {
                for (int j = 0; j < CurrentMap.Size; j++)
                {
                    if (!CurrentMap.Map[i, j])
                        _freeCells.Add((i, j));
                }
            }
        }

        private void RemoveLiveOrWin(MoveDirection direction)
        {
            if (Cow.Column == CurrentMap.Size - 1 && Cow.Row == CurrentMap.Size - 1)
                OnGameResult?.Invoke(this, true);
            if (Cow.Column != Wolf.Column) return;
            if (Cow.Row != Wolf.Row) return;
            Cow.Lives.Remove(Cow.Lives.Last());
            if (Cow.Lives.Count == 0)
            {
                OnGameResult?.Invoke(this, false);
            }
        }

        private void InitBricks()
        {
            for (int i = 0; i < CurrentMap.Size; i++)
            {
                for (int j = 0; j < CurrentMap.Size; j++)
                {
                    if (CurrentMap.Map[i, j])
                    {
                        Bricks.Add(new BrickViewModel()
                        {
                            Column = j,
                            Row = i
                        });
                    }
                }
            }
        }

        private bool IsBlockOn(int row, int column, MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Down:
                {
                    if (row + 1 == CurrentMap.Size)
                        return true;
                    return Bricks.SingleOrDefault(x => x.Row == row + 1 && x.Column == column) != null;
                }

                case MoveDirection.Up:
                {
                    if (row - 1 == -1)
                        return true;
                    return Bricks.SingleOrDefault(x => x.Row == row - 1 && x.Column == column) != null;
                }

                case MoveDirection.Left:
                {
                    if (column - 1 == -1)
                        return true;
                    return Bricks.SingleOrDefault(x => x.Row == row && x.Column == column - 1) != null;
                }

                case MoveDirection.Right:
                {
                    if (column + 1 == CurrentMap.Size)
                        return true;
                    return Bricks.SingleOrDefault(x => x.Row == row && x.Column == column + 1) != null;
                }

                default:
                {
                    return Bricks.SingleOrDefault(x => x.Row == row && x.Column == column) != null;
                }
            }
        }

        private async Task SpawnBomb()
        {
            await Task.Delay(Bomb.Settings.Delay);
            Bomb.Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\bomb.png";
            int placeToPaste = _randomBomb.Next(0, _freeCells.Count);
            Bomb.Row = _freeCells[placeToPaste].Item1;
            Bomb.Column = _freeCells[placeToPaste].Item2;
            await BombExplode();
        }

        private async Task BombExplode()
        {
            await Task.Delay(Bomb.Settings.Delay);
            Bomb.Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\explosion.png";
            SpawnBomb();
        }

        private async Task SpawnCannabis()
        {
            await Task.Delay(Cannabis.Settings.Delay / 2);
            int placeToPaste = _randomCannabis.Next(0, _freeCells.Count);
            Cannabis.Row = _freeCells[placeToPaste].Item1;
            Cannabis.Column = _freeCells[placeToPaste].Item2;
            await RemoveCannabis();
        }

        private async Task RemoveCannabis()
        {
            await Task.Delay(Cannabis.Settings.Delay);
            Cannabis.Row = -1;
            Cannabis.Column = -1;
            SpawnCannabis();
        }
    }
}
