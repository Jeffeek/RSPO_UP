using System;
using System.Collections.Generic;
using System.Linq;

namespace RSPO.Library._8
{
    public class MatrixTasks
    {
		/// <summary>
		/// Даны целые положительные числа M, N и набор из M чисел.
		/// Сформировать матрицу размера M × N, у которой в каждом столбце содержатся
		/// все числа из исходного набора (в том же порядке).
		/// </summary>
		/// <param name="m"></param>
		/// <param name="n"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public int[,] CreateColumnedMatrix(int m, int n, IEnumerable<int> values)
        {
            if(values.Count() != m) throw new ArgumentException(nameof(values));
            var matrix = new int[m, n];
            var valuesAsArray = values.ToArray();
            for(var i = 0; i < n; i++)
            {
	            for(var j = 0; j < m; j++)
	            {
		            matrix[j, i] = valuesAsArray[j];
	            }
            }

            return matrix;
        }

		/// <summary>
		/// Дана матрица размера M × N. Найти номера строки и столбца для
		/// элемента матрицы, наиболее близкого к среднему значению всех ее элементов.
		/// </summary>
		/// <param name="matrix"></param>
		/// <returns></returns>
		public ValueTuple<int, int> GetIndexesNearAvg(int[,] matrix)
        {
	        var avg = Avg(matrix);
	        var error = avg;
	        int row = 0, column = 0;
	        for (var i = 0; i < matrix.GetLength(0); i++)
	        {
		        for (var j = 0; j < matrix.GetLength(1); j++)
		        {
			        if(matrix[j, i] > avg)
			        {
				        if (matrix[j, i] - avg < error)
					        error = matrix[j, i] - avg;
				        row = i;
				        column = j;
			        }
					else if(matrix[j, i] < avg)
			        {
				        if (avg - matrix[j, i] < error)
					        error = avg - matrix[j, i];
				        row = i;
				        column = j;
			        }
			        else
			        {
				        error = matrix[j, i];
				        row = i;
				        column = j;
			        }
				}
	        }

	        return (row, column);
        }

        private double Avg(int[,] matrix)
        {
	        if(matrix == null) throw new ArgumentException(nameof(matrix));
	        int sum = 0;
	        for(var i = 0; i < matrix.GetLength(0); i++)
	        {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
	                sum += matrix[i, j];
                }
	        }

	        return (double)sum / (matrix.GetLength(0) * matrix.GetLength(1));
        }
    }
}
