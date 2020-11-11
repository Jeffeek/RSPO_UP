using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using RSPO_UP_5.Model;

namespace RSPO_UP_5.ViewModel
{
    public class MatrixWindowViewModel : ViewModelBase
    {
        private DataTable _firstMatrix, _secondMatrix;
        private int _firstMatrixRowsCount, _firstMatrixColumnsCount;
        private int _secondMatrixRowsCount, _secondMatrixColumnsCount;
        private bool _isFirstMatrixReadonly, _isSecondMatrixReadonly;
        public DataTable FirstMatrix 
        { 
            get => _firstMatrix; 
            set => SetValue(ref _firstMatrix, value);
        }

        public bool IsFirstMatrixReadOnly
        {
            get => _isFirstMatrixReadonly;
            set => SetValue(ref _isFirstMatrixReadonly, value);
        }


        public DataTable SecondMatrix
        {
            get => _secondMatrix;
            set => SetValue(ref _secondMatrix, value);
        }

        public bool IsSecondMatrixReadOnly
        {
            get => _isSecondMatrixReadonly;
            set => SetValue(ref _isSecondMatrixReadonly, value);
        }

        #region MyRegion

        public string FirstMatrixRowsCount
        {
            get => _firstMatrixRowsCount.ToString();
            set
            {
                if (int.TryParse(value, out int rows))
                {
                    SetValue(ref _firstMatrixRowsCount, rows);
                    OnPropertyChanged(nameof(FirstMatrixRowsCount));
                }
                else
                {
                    return;
                }
            }
        }

        public string FirstMatrixColumnsCount
        {
            get => _firstMatrixColumnsCount.ToString();
            set
            {
                if (int.TryParse(value, out int columns))
                {
                    SetValue(ref _firstMatrixColumnsCount, columns);
                    OnPropertyChanged(nameof(FirstMatrixColumnsCount));
                }
                else
                {
                    return;
                }
            }
        }

        #endregion

        public ICommand TransposeFirstMatrixCommand { get; }
        public ICommand TransposeSecondMatrixCommand { get; }
        public ICommand ReverseFirstMatrixCommand { get; }
        public ICommand ReverseSecondMatrixCommand { get; }
        public ICommand MultiplyFirstAndSecondMatrixesCommand { get; }
        public ICommand FillFirstMatrixRandomlyCommand { get; }
        public ICommand FillFirstMatrixByHandCommand { get; }

        private void FillFirstMatrixRandomlyExecuted()
        {
            IsFirstMatrixReadOnly = true;
            var mw = new MatrixWorker();
            FirstMatrix = mw.GetTable(mw.FillMatrixRandomly(_firstMatrixRowsCount, _firstMatrixColumnsCount));
        }

        private void FillFirstMatrixByHandExecuted()
        {
            IsFirstMatrixReadOnly = false;
            var mw = new MatrixWorker();
            FirstMatrix = mw.GetTable(mw.FillMatrixZeros(_firstMatrixRowsCount, _firstMatrixColumnsCount));
        }

        public MatrixWindowViewModel()
        {
            FillFirstMatrixRandomlyCommand = new RelayCommand(FillFirstMatrixRandomlyExecuted);
            FillFirstMatrixByHandCommand = new RelayCommand(FillFirstMatrixByHandExecuted);
        }
    }
}
