using System;
using System.Text;

namespace RSPO_UP_5.Model
{
    public class Matrix : IEquatable<Matrix>, IDisposable
    {
        private bool _isDisposed;
        private readonly int[,] _innerMatrix;
        public int ColumnsCount { get; }
        public int RowsCount { get; }

        public int this[int row, int column]
        {
            get => _innerMatrix[row, column];
            set => _innerMatrix[row, column] = value;
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            ColumnsCount = columnsCount;
            RowsCount = rowsCount;
            _innerMatrix = new int[rowsCount,columnsCount];
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
                        matrix[i, j] += _innerMatrix[i, k] * b[k, j];
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
                        matrix[i, j] += _innerMatrix[i, k] * _innerMatrix[k, j];
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
                    matrix[i, j] = _innerMatrix[i, j] + b[i, j];
                }
            }

            return matrix;
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
