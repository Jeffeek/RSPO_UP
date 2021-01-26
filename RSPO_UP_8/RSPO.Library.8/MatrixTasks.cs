#region Using namespaces

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace RSPO.Library._8
{
	public class MatrixTasks
	{
		/// <summary>
		///     Формирует новую матрицу, у которой в каждом столбце содержаться
		///     все числа из
		///     <param name="values"></param>
		///     в том же порядке
		/// </summary>
		/// <param name="rowsCount"></param>
		/// <param name="columnsCount"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public int[,] CreateColumnedMatrix(int rowsCount, int columnsCount, IEnumerable<int> values)
		{
			var enumerable = values as int[] ?? values.ToArray();
			if (enumerable.Count() != rowsCount) throw new ArgumentException(nameof(values));
			var matrix = new int[rowsCount, columnsCount];
			var valuesAsArray = enumerable.ToArray();
			for (var i = 0; i < columnsCount; i++)
			{
				for (var j = 0; j < rowsCount; j++) matrix[j, i] = valuesAsArray[j];
			}

			return matrix;
		}

		/// <summary>
		///     Возвращает индексы строки и столбца элемента, который максимально близок к
		///     среднему арифметическому матрицы
		/// </summary>
		/// <param name="matrix">Исходная матрица</param>
		/// <returns>Индексы строки и столбца в формате <see cref="ValueTuple" /></returns>
		public ValueTuple<int, int> GetIndexesNearAvg(int[,] matrix)
		{
			var avg = Avg(matrix);

			int row = 0, column = 0;
			for (var i = 0; i < matrix.GetLength(0); i++)
			{
				for (var j = 0; j < matrix.GetLength(1); j++)
				{
					if (Math.Abs(avg - matrix[row, column]) > Math.Abs(avg - matrix[i, j]))
					{
						row = i;
						column = j;
					}
				}
			}

			return (row, column);
		}

		/// <summary>
		///     Возвращает среднее арифметическое матрицы
		/// </summary>
		/// <param name="matrix"></param>
		/// <returns>Среднее арифметическое матрицы</returns>
		private double Avg(int[,] matrix)
		{
			if (matrix == null) throw new ArgumentException(nameof(matrix));
			var sum = 0;
			for (var i = 0; i < matrix.GetLength(0); i++)
			{
				for (var j = 0; j < matrix.GetLength(1); j++) sum += matrix[i, j];
			}

			return (double) sum / (matrix.GetLength(0) * matrix.GetLength(1));
		}

		public int GetMaxSteps(int[,] matrix, int sum) => GetMaxStepsInternal(matrix, matrix.GetLength(0) - 1,
		                                                                      matrix.GetLength(1) - 1,
		                                                                      sum -
		                                                                      matrix[matrix.GetLength(0) - 1,
			                                                                      matrix.GetLength(1) - 1]);

		/// <summary>
		///     Дан двумерный массив. Каждая ячейка имеет вес указанный в матрице,
		///     необходимо пройти наибольшее количество шагов имею сумму n.
		///     Начиная с правого верхнего. Каждый шаг её уменьшает на значения в матрице.
		/// </summary>
		private int GetMaxStepsInternal(int[,] matrix,
		                                int rowIndex,
		                                int columnIndex,
		                                int maxDistance,
		                                int stepsCount = 0)
		{
			if (maxDistance <= 0 ||
			    rowIndex < 0 ||
			    columnIndex < 0 ||
			    rowIndex >= matrix.GetLength(0) ||
			    columnIndex >= matrix.GetLength(1)) return stepsCount;

			var variants =
				new List<(int, int)> {(-1, 0), (1, 0), (0, -1), (0, 1)}.Where(el => el.Item1 + rowIndex >= 0 &&
					                                                              el.Item1 + rowIndex <
					                                                              matrix.GetLength(0) &&
					                                                              el.Item2 + columnIndex >= 0 &&
					                                                              el.Item2 + columnIndex <
					                                                              matrix.GetLength(1));

			var value = variants.Select(el => GetMaxStepsInternal(matrix, rowIndex + el.Item1, columnIndex + el.Item2,
			                                                      maxDistance -
			                                                      matrix[rowIndex + el.Item1, columnIndex + el.Item2],
			                                                      stepsCount + 1))
			                    .Max();

			return value;
		}
	}
}