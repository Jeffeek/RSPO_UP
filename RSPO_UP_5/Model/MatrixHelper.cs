#region Using namespaces

using System;

#endregion

namespace RSPO_UP_5.Model
{
	public class MatrixHelper
	{
		public Matrix FillMatrixRandomly(Matrix matrix)
		{
			var rnd = new Random();
			for (var i = 0; i < matrix.RowsCount; i++)
			{
				for (var j = 0; j < matrix.ColumnsCount; j++)
					matrix[i, j] = rnd.Next(-50, 50);
			}

			return matrix;
		}

		public Matrix FillMatrixZeros(Matrix matrix)
		{
			for (var i = 0; i < matrix.RowsCount; i++)
			{
				for (var j = 0; j < matrix.ColumnsCount; j++)
					matrix[i, j] = 0;
			}

			return matrix;
		}
	}
}