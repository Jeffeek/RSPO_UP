using System;
using System.Collections.ObjectModel;
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

        private void CowWalkedEventHandler(int row, int column, MoveDirection direction)
        {

        }

        private void BombExplodedEventHandler(int row, int column)
        {

        }

        private void WolfWalkedEventHandler(int row, int column)
        {

        }

        private void CannabisChangedPositionEventHandler(int row, int column)
        {

        }

        #endregion

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

        public MapViewModel(IMap map)
        {
            Map = map;
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

            _bricks = new ObservableCollection<BrickViewModel>();
            SetBricksInPosition();
        }
    }
}
