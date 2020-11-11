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

        public DataTable GetTable(int[,] matrix)
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
    }
}
