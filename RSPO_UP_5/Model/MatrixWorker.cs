using System;
using System.Collections.ObjectModel;
using System.Data;

namespace RSPO_UP_5.Model
{
    public class MatrixWorker
    {
        public int[,] FillMatrixRandomly(int rows, int columns)
        {
            var rnd = new Random();
            var list = new int[rows,columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    list[i,j] = rnd.Next(-20, 50);
            }
            return list;
        }

        public int[,] FillMatrixZeros(int rows, int columns)
        {
            var list = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    list[i, j] = 0;
            }
            return list;
        }

        public DataTable ConvertToDataTable(int[,] matrix)
        {
            var table = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
                table.Columns.Add();
            for (int i = 0; i < matrix.GetLength(0); i++)
                table.Rows.Add();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    table.Rows[i][j] = matrix[i, j];
                }
            }

            return table;
        }

        public int[,] Transpose(int[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            int[,] result = new int[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        public int[,] ConvertFromDataTable(DataTable table)
        {
            var matrix = new int[table.Rows.Count, table.Columns.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    matrix[i, j] = int.Parse(table.Rows[i][j].ToString());
                }
            }

            return matrix;
        }

        public int[,] Multiplication(int[,] a, int[,] b)
        {
            if (a.GetLength(1) == b.GetLength(0)) return InternalMulAtoB(a, b);
            if (b.GetLength(1) == a.GetLength(0)) return InternalMulBtoA(a, b);
            throw new Exception("Не поддерживается перемножение");
        }

        private int[,] InternalMulAtoB(int[,] a, int[,] b)
        {
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return r;
        }

        private int[,] InternalMulBtoA(int[,] a, int[,] b)
        {
            int[,] r = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * a[k, j];
                    }
                }
            }

            return r;
        }

        public int[,] Sum(int[,] a, int[,] b)
        {
            int[,] r = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    r[i, j] = a[i, j] + b[i, j];
                }
            }

            return r;
        }
    }
}
