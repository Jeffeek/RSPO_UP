using System;
using System.Collections.ObjectModel;
using System.Linq;
using RSPO_UP_6.Model.Controllers;
using RSPO_UP_6.Model.Map;
using RSPO_UP_6.ViewModel.Entities;

namespace RSPO_UP_6.ViewModel
{
    public class MapViewModel : ViewModelBase
    {
        public event EventHandler<bool> OnGameResult;

        #region Fields

        private IMap _map;
        private CowViewModel _cow;
        private WolfViewModel _wolf;
        private CannabisViewModel _cannabis;
        private BombViewModel _bomb;
        private ObservableCollection<BrickViewModel> _bricks;
        private bool _isGameStopped = false;

        #endregion

        #region Properties

        public ObservableCollection<BrickViewModel> Bricks
        {
            get => _bricks;
            set => SetValue(ref _bricks, value);
        }

        public bool IsGameStopped
        {
            get => _isGameStopped;
            set
            {
                SetValue(ref _isGameStopped, value);
                Cannabis.IsGameStopped = value;
                Bomb.IsGameStopped = value;
            }
        }

        public IMap Map
        {
            get => _map;
            set => SetValue(ref _map, value);
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

        public CowViewModel Cow
        {
            get => _cow;
            set => SetValue(ref _cow, value);
        }

        #endregion

        #region Event Handlers

        private void CowChangedPositionEventHandler(int row, int column)
        {
            if (row == Map.Size - 1 && column == Map.Size - 1)
            {
                OnGameResult?.Invoke(this, true);
                return;
            }

            CheckCowForCannabis();
            CheckCowForBomb();
        }

        private void BombExplodedEventHandler(int row, int column)
        {
            if (row == Cow.Row && column == Cow.Column)
            {
                var live = Cow.Lives.Last();
                Cow.Lives.Remove(live);
                CheckCowForDying();
            }
        }

        private void WolfWalkedEventHandler(int row, int column)
        {
            if (row == Cow.Row && column == Cow.Column)
            {
                var live = Cow.Lives.Last();
                Cow.Lives.Remove(live);
                CheckCowForDying();
            }
        }

        private void CannabisChangedPositionEventHandler(int row, int column)
        {
            if (row != Cow.Row || column != Cow.Column) return;
            if (Cow.Lives.Count == 7) return;
            if (Cannabis.IsCollected) return;
            var item = new LiveViewModel();
            Cow.Lives.Add(item);
            Cannabis.IsCollected = true;
        }

        #endregion

        private bool IsCowDied() => Cow.Lives.Count == 0;

        private void CheckCowForCannabis()
        {
            if (Cow.Row != Cannabis.Row) return;
            if (Cow.Column != Cannabis.Column) return;
            if (Cannabis.IsCollected) return;
            if (Cow.Lives.Count == 7) return;
            var item = new LiveViewModel();
            Cow.Lives.Add(item);
            Cannabis.IsCollected = true;
        }

        private void CheckCowForBomb()
        {
            if (Cow.Row != Bomb.Row) return;
            if (Cow.Column != Bomb.Column) return;
            if (!Bomb.IsExploded) return;
            var item = Cow.Lives.Last();
            Cow.Lives.Remove(item);
        }

        private void CheckCowForDying()
        {
            if (IsCowDied())
            {
                IsGameStopped = true;
                //OnGameResult?.Invoke(this, false);
                return;
            }
        }

        private void SetBricksInPosition()
        {
            for (int i = 0; i < Map.Size; i++)
            {
                for (int j = 0; j < Map.Size; j++)
                {
                    if (Map.Map[i, j])
                        _bricks.Add(new BrickViewModel() {Column = j, Row = i});
                }
            }
        }

        public void StartMap()
        {
            Bomb = new BombViewModel((row, column) => Map.IsCellFree(row, column));
            Cannabis = new CannabisViewModel((row, column) => Map.IsCellFree(row, column));
            Cow = new CowViewModel((row, column) => Map.IsCellFree(row, column))
            {
                Column = 0,
                Row = 0
            };
            Wolf = new WolfViewModel((row, column) => Map.IsCellFree(row, column))
            {
                Column = Map.Size - 1,
                Row = 0
            };
            Cow.CowMovedTo += Wolf.CowMovedEventHandler;
            Wolf.WolfPositionChanged += WolfWalkedEventHandler;
            Cannabis.CannabisPositionChanged += CannabisChangedPositionEventHandler;
            Bomb.BombExploded += BombExplodedEventHandler;
            Cow.CowPositionChanged += CowChangedPositionEventHandler;
        }

        public MapViewModel(IMap map)
        {
            Map = map;
            _bricks = new ObservableCollection<BrickViewModel>();
            SetBricksInPosition();
        }
    }
}
