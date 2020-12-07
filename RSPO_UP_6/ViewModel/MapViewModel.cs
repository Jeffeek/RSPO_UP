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
            CurrentMap = map;
            _freeCells = new List<(int, int)>();
            FillFreeCells();
            Cow = new CowViewModel(IsBlockOn);
            Wolf = new WolfViewModel(IsBlockOn)
            {
                Column = CurrentMap.Size - 1,
                Row = 0
            };
            Cow.CowPositionChanged += Wolf.CowMovedExecuted;
            Cow.CowPositionChanged += CowChangedPosition;
            Cow.CowPositionChanged += CheckCowState;
            Bomb = new BombViewModel(_freeCells);
            Bomb.BombStateChanged += BombChangedStateHandler;
            Cannabis = new CannabisViewModel(_freeCells);
            InitBricks();
        }

        private void CowChangedPosition(MoveDirection direction)
        {
            if (Cow.Row != Cannabis.Row || Cow.Column != Cannabis.Column) return;
            Cow.Lives.Add(new LiveViewModel());
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

        private void BombChangedStateHandler(object bomb, bool state)
        {
            if (state == false) return;
            if (Cow.Row != Bomb.Row || Cow.Column != Bomb.Column) return;
            Cow.Lives.Remove(Cow.Lives.Last());
            if (Cow.Lives.Count == 0)
                OnGameResult?.Invoke(this, false);
        }

        private void CheckCowState(MoveDirection direction)
        {
            if (Cow.Column == CurrentMap.Size - 1 && Cow.Row == CurrentMap.Size - 1)
                OnGameResult?.Invoke(this, true);
            if (Cow.Column == Wolf.Column && Cow.Row == Wolf.Row)
                Cow.Lives.Remove(Cow.Lives.Last());
            if (Cow.Lives.Count == 0)
                OnGameResult?.Invoke(this, false);
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
    }
}
