using System;
using System.Text;

namespace RSPO_UP_5.Model
{
    public class Matrix : IEquatable<Matrix>, IDisposable
    {
        private bool _isDisposed;
        private readonly double[,] _innerMatrix;
        public int ColumnsCount { get; }
        public int RowsCount { get; }
        public bool IsSquare => RowsCount == ColumnsCount;

        public double this[int row, int column]
        {
            get => Math.Round(_innerMatrix[row, column], 2);
            set => _innerMatrix[row, column] = Math.Round(value, 2);
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            ColumnsCount = columnsCount;
            RowsCount = rowsCount;
            _innerMatrix = new double[rowsCount,columnsCount];
        }

        public static Matrix operator *(Matrix a, Matrix b) => a.Multiplication(b);
        public static Matrix operator +(Matrix a, Matrix b) => a.Add(b);

        public Matrix Multiplication(Matrix b)
        {
            if (_innerMatrix.GetLength(1) == b.RowsCount) return InternalMulAtoB(b);
            if (b.ColumnsCount == _innerMatrix.GetLength(0)) return InternalMulBtoA(b);
            throw new Exception("Не поддерживается перемножение");
        }

        private Matrix InternalMulAtoB(Matrix b)
        {
            var matrix = new Matrix(_innerMatrix.GetLength(0), b.ColumnsCount);
            for (int i = 0; i < _innerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < b.ColumnsCount; j++)
                {
                    for (int k = 0; k < b.RowsCount; k++)
                    {
                        matrix[i, j] += Math.Round(_innerMatrix[i, k] * b[k, j], 2);
                    }
                }
            }

            return matrix;
        }

        private Matrix InternalMulBtoA(Matrix b)
        {
            var matrix = new Matrix(_innerMatrix.GetLength(0), _innerMatrix.GetLength(1));
            for (int i = 0; i < _innerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _innerMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < _innerMatrix.GetLength(0); k++)
                    {
                        matrix[i, j] += Math.Round(_innerMatrix[i, k] * _innerMatrix[k, j], 2);
                    }
                }
            }

            return matrix;
        }

        public Matrix Transpose()
        {
            int w = _innerMatrix.GetLength(0);
            int h = _innerMatrix.GetLength(1);

            Matrix result = new Matrix(h, w);

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = _innerMatrix[i, j];
                }
            }

            return result;
        }

        public Matrix Add(Matrix b)
        {
            var matrix = new Matrix(_innerMatrix.GetLength(0), _innerMatrix.GetLength(1));
            for (int i = 0; i < _innerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _innerMatrix.GetLength(1); j++)
                {
                    matrix[i, j] = Math.Round(_innerMatrix[i, j] + b[i, j], 2);
                }
            }

            return matrix;
        }

        public static Matrix CreateIdentityMatrix(int n)
        {
            var result = new Matrix(n, n);
            for (var i = 0; i < n; i++)
            {
                result[i, i] = 1;
            }
            return result;
        }

        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < RowsCount; i++)
            {
                for (var j = 0; j < ColumnsCount; j++)
                {
                    func?.Invoke(i, j);
                }
            }
        }

        private Matrix CreateMatrixWithoutColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= ColumnsCount)
            {
                throw new ArgumentException("invalid column index");
            }
            var result = new Matrix(RowsCount, ColumnsCount - 1);
            result.ProcessFunctionOverData((i, j) =>
                result[i, j] = j < columnIndex ? this[i, j] : this[i, j + 1]);
            return result;
        }

        private Matrix CreateMatrixWithoutRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= RowsCount)
            {
                throw new ArgumentException("invalid row index");
            }
            var result = new Matrix(RowsCount-1, ColumnsCount);
            result.ProcessFunctionOverData((i, j) =>
                result[i, j] = i < rowIndex ? this[i, j] : this[i + 1, j]);
            return result;
        }

        public double CalculateDeterminant()
        {
            if (!IsSquare)
            {
                throw new InvalidOperationException(
                    "determinant can be calculated only for square matrix");
            }
            if (ColumnsCount == 2)
            {
                return Math.Round(this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0], 2);
            }
            double result = 0;
            for (var j = 0; j < ColumnsCount; j++)
            {
                result += Math.Round((j % 2 == 1 ? 1 : -1) * this[1, j] *
                          CreateMatrixWithoutColumn(j)
                              .CreateMatrixWithoutRow(1)
                              .CalculateDeterminant(),2);
            }
            return result;
        }

        public Matrix CreateInvertibleMatrix()
        {
            if (!IsSquare)
                return null;
            var determinant = CalculateDeterminant();

            var result = new Matrix(RowsCount, ColumnsCount);
            ProcessFunctionOverData((i, j) =>
            {
                result[i, j] = Math.Round((i + j) % 2 == 1 ? -1 : 1 *
                    CalculateMinor(i, j) / determinant, 2);
            });

            result = result.Transpose();
            return result;
        }

        private double CalculateMinor(int i, int j)
        {
            return Math.Round(CreateMatrixWithoutColumn(j)
                .CreateMatrixWithoutRow(i)
                .CalculateDeterminant(),2);
        }

        public string GetAsString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    sb.Append( $"{this[i, j]} | ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public override string ToString() => GetAsString();

        public bool Equals(Matrix other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_innerMatrix, other._innerMatrix) && 
                   ColumnsCount == other.ColumnsCount && 
                   RowsCount == other.RowsCount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Matrix) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_innerMatrix != null ? _innerMatrix.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ColumnsCount;
                hashCode = (hashCode * 397) ^ RowsCount;
                return hashCode;
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
