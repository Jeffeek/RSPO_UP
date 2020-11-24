using System.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_5.Model;

namespace RSPO_UP_5.ViewModel
{
    public class MatrixWindowViewModel : ViewModelBase
    {
        private DataTable _firstMatrix, _secondMatrix;
        private int _firstMatrixRowsCount, _firstMatrixColumnsCount;
        private int _secondMatrixRowsCount, _secondMatrixColumnsCount;
        private bool _isFirstMatrixReadonly, _isSecondMatrixReadonly;
        private bool _isFirstMatrixFilled, _isSecondMatrixFilled;

        #region data tables

        public DataTable FirstMatrix 
        { 
            get => _firstMatrix; 
            set => SetValue(ref _firstMatrix, value);
        }

        public DataTable SecondMatrix
        {
            get => _secondMatrix;
            set => SetValue(ref _secondMatrix, value);
        }

        #endregion

        #region readonly options

        public bool IsFirstMatrixReadOnly
        {
            get => _isFirstMatrixReadonly;
            set => SetValue(ref _isFirstMatrixReadonly, value);
        }


        public bool IsSecondMatrixReadOnly
        {
            get => _isSecondMatrixReadonly;
            set => SetValue(ref _isSecondMatrixReadonly, value);
        }

        #endregion

        #region Rows and cols first Matrix

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
            }
        }

        #endregion

        #region Rows and cols second Matrix

        public string SecondMatrixRowsCount
        {
            get => _secondMatrixRowsCount.ToString();
            set
            {
                if (int.TryParse(value, out int rows))
                {
                    SetValue(ref _secondMatrixRowsCount, rows);
                    OnPropertyChanged(nameof(FirstMatrixRowsCount));
                }
            }
        }

        public string SecondMatrixColumnsCount
        {
            get => _secondMatrixColumnsCount.ToString();
            set
            {
                if (int.TryParse(value, out int columns))
                {
                    SetValue(ref _secondMatrixColumnsCount, columns);
                    OnPropertyChanged(nameof(SecondMatrixColumnsCount));
                }
            }
        }

        #endregion

        #region commands

        public ICommand TransposeFirstMatrixCommand { get; }
        public ICommand TransposeSecondMatrixCommand { get; }
        public ICommand MultiplyFirstAndSecondMatricesCommand { get; }
        public ICommand AddFirstAndSecondMatricesCommand { get; }
        public ICommand FillFirstMatrixRandomlyCommand { get; }
        public ICommand FillFirstMatrixByHandCommand { get; }
        public ICommand FillSecondMatrixRandomlyCommand { get; }
        public ICommand FillSecondMatrixByHandCommand { get; }
        public ICommand ReverseFirstMatrixCommand { get; }
        public ICommand ReverseSecondMatrixCommand { get; }

        #endregion

        #region first matrix fill

        private void FillFirstMatrixRandomlyExecuted()
        {
            IsFirstMatrixReadOnly = true;
            var matrixHelper = new MatrixHelper();
            var converter = new MatrixConverter();
            var matrix = new Matrix(_firstMatrixRowsCount, _firstMatrixColumnsCount);
            var filledMatrix = matrixHelper.FillMatrixRandomly(matrix);
            FirstMatrix = converter.ConvertToDataTable(filledMatrix);
            _isFirstMatrixFilled = true;
        }

        private void FillFirstMatrixByHandExecuted()
        {
            IsFirstMatrixReadOnly = false;
            var matrixHelper = new MatrixHelper();
            var converter = new MatrixConverter();
            var matrix = new Matrix(_firstMatrixRowsCount, _firstMatrixColumnsCount);
            var filledMatrix = matrixHelper.FillMatrixZeros(matrix);
            FirstMatrix = converter.ConvertToDataTable(filledMatrix);
            _isSecondMatrixFilled = true;
        }

        private bool CanFillFirstMatrixExecute() => _firstMatrixColumnsCount > 0 &&
                                                    _firstMatrixRowsCount > 0;

        #endregion

        #region second matrix fill

        private void FillSecondMatrixRandomlyExecuted()
        {
            IsSecondMatrixReadOnly = true;
            var matrixHelper = new MatrixHelper();
            var converter = new MatrixConverter();
            var matrix = new Matrix(_secondMatrixRowsCount, _secondMatrixColumnsCount);
            var filledMatrix = matrixHelper.FillMatrixRandomly(matrix);
            SecondMatrix = converter.ConvertToDataTable(filledMatrix);
            _isSecondMatrixFilled = true;
        }

        private void FillSecondMatrixByHandExecuted()
        {
            IsSecondMatrixReadOnly = false;
            var matrixHelper = new MatrixHelper();
            var converter = new MatrixConverter();
            var matrix = new Matrix(_secondMatrixRowsCount, _secondMatrixColumnsCount);
            var filledMatrix = matrixHelper.FillMatrixZeros(matrix);
            SecondMatrix = converter.ConvertToDataTable(filledMatrix);
            _isSecondMatrixFilled = true;
        }

        private bool CanFillSecondMatrixExecute() => _secondMatrixColumnsCount > 0 &&
                                                     _secondMatrixRowsCount > 0;

        #endregion

        #region transpose

        public void TransposeFirstMatrixExecuted()
        {
            IsFirstMatrixReadOnly = false;
            var converter = new MatrixConverter();
            var matrix = converter.ConvertFromDataTable(FirstMatrix);
            var matrixT = matrix.Transpose();
            var table = converter.ConvertToDataTable(matrixT);
            FirstMatrix = table;
            _firstMatrixRowsCount = FirstMatrix.Rows.Count;
            _firstMatrixColumnsCount = FirstMatrix.Columns.Count;
        }

        private bool CanTransposeFirstMatrix() => _isFirstMatrixFilled;

        public void TransposeSecondMatrixExecuted()
        {
            IsSecondMatrixReadOnly = false;
            var converter = new MatrixConverter();
            var matrix = converter.ConvertFromDataTable(SecondMatrix);
            var matrixT = matrix.Transpose();
            var table = converter.ConvertToDataTable(matrixT);
            SecondMatrix = table;
            _secondMatrixRowsCount = SecondMatrix.Rows.Count;
            _secondMatrixColumnsCount = SecondMatrix.Columns.Count;
        }

        private bool CanTransposeSecondMatrix() => _isSecondMatrixFilled;

        #endregion

        #region multiply

        private void MultiplyFirstAndSecondMatricesExecuted()
        {
            var converter = new MatrixConverter();
            var firstMatrix = converter.ConvertFromDataTable(FirstMatrix);
            var secondMatrix = converter.ConvertFromDataTable(SecondMatrix);
            var newMatrix = firstMatrix.Multiplication(secondMatrix);
            var newTable = converter.ConvertToDataTable(newMatrix);
            FirstMatrix = newTable;
            _isFirstMatrixFilled = true;
            _isSecondMatrixFilled = false;
            SecondMatrix = null;
        }

        private bool CanMultiplyMatrices() => _isFirstMatrixFilled &&
                                              _isSecondMatrixFilled &&
                                              _firstMatrixColumnsCount == _secondMatrixRowsCount &&
                                              _firstMatrixRowsCount == _secondMatrixColumnsCount;

        #endregion

        #region sum

        private void AddMatrices()
        {
            var converter = new MatrixConverter();
            var firstMatrix = converter.ConvertFromDataTable(FirstMatrix);
            var secondMatrix = converter.ConvertFromDataTable(SecondMatrix);
            var newMatrix = firstMatrix.Add(secondMatrix);
            var newTable = converter.ConvertToDataTable(newMatrix);
            FirstMatrix = newTable;
            _isFirstMatrixFilled = true;
            _isSecondMatrixFilled = false;
            SecondMatrix = null;
        }

        private bool CanSumMatrices() => _isFirstMatrixFilled &&
                                         _isSecondMatrixFilled &&
                                         _firstMatrixColumnsCount == _secondMatrixColumnsCount &&
                                         _firstMatrixRowsCount == _secondMatrixRowsCount;

        #endregion

        private void ReverseFirstMatrixExecuted()
        {
            IsFirstMatrixReadOnly = false;
            var converter = new MatrixConverter();
            var matrix = converter.ConvertFromDataTable(FirstMatrix);
            var invertedMatrix = matrix.CreateInvertibleMatrix();
            FirstMatrix = converter.ConvertToDataTable(invertedMatrix);
        }

        private bool CanReverseFirstMatrixExecute() => FirstMatrix?.Columns.Count == FirstMatrix?.Rows.Count;

        private void ReverseSecondMatrixExecuted()
        {
            IsSecondMatrixReadOnly = false;
            var converter = new MatrixConverter();
            var matrix = converter.ConvertFromDataTable(SecondMatrix);
            var invertedMatrix = matrix.CreateInvertibleMatrix();
            SecondMatrix = converter.ConvertToDataTable(invertedMatrix);
        }

        private bool CanReverseSecondMatrixExecute() => SecondMatrix?.Columns.Count == SecondMatrix?.Rows.Count;

        public MatrixWindowViewModel()
        {
            FillFirstMatrixRandomlyCommand = new RelayCommand(FillFirstMatrixRandomlyExecuted, CanFillFirstMatrixExecute);
            FillFirstMatrixByHandCommand = new RelayCommand(FillFirstMatrixByHandExecuted, CanFillFirstMatrixExecute);
            FillSecondMatrixRandomlyCommand = new RelayCommand(FillSecondMatrixRandomlyExecuted, CanFillSecondMatrixExecute);
            FillSecondMatrixByHandCommand = new RelayCommand(FillSecondMatrixByHandExecuted, CanFillSecondMatrixExecute);
            TransposeFirstMatrixCommand = new RelayCommand(TransposeFirstMatrixExecuted, CanTransposeFirstMatrix);
            TransposeSecondMatrixCommand = new RelayCommand(TransposeSecondMatrixExecuted, CanTransposeSecondMatrix);
            MultiplyFirstAndSecondMatricesCommand = new RelayCommand(MultiplyFirstAndSecondMatricesExecuted, CanMultiplyMatrices);
            AddFirstAndSecondMatricesCommand = new RelayCommand(AddMatrices, CanSumMatrices);
            ReverseFirstMatrixCommand = new RelayCommand(ReverseFirstMatrixExecuted, CanReverseFirstMatrixExecute);
            ReverseSecondMatrixCommand = new RelayCommand(ReverseSecondMatrixExecuted, CanReverseSecondMatrixExecute);
        }
    }
}
