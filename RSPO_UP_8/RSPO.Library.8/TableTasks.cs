#region Using namespaces

using System;

#endregion

namespace RSPO.Library._8
{
	public class TableTasks
	{
		/// <summary>
		///     Находит такой путь из клетки [0,0] в клетку [n,m], что бы сумма цифр
		///     в клетках, через которые он пролегает, была минимальной
		/// </summary>
		public void ShortWay(int[,] table, out char[,] result)
		{
			if (ReferenceEquals(table, null)) throw new ArgumentNullException(nameof(table));
			if (table.GetLength(0) != table.GetLength(1)) throw new ArgumentException("Таблица должна быть квадратной");
			var length = table.GetLength(0);
			result = new char[length, length];
			var maxLength = (length - 1) * (length - 1) * 9 + 1;
			var min = new int[length, length];
			for (var i = 0; i < length; i++)
			{
				for (var j = 0; j < length; j++)
					min[i, j] = maxLength;
			}

			min[0, 0] = table[0, 0];

			for (var i = 0; i < length; i++)
			{
				for (var j = 0; j < length; j++)
				{
					if (i != length - 1)
					{
						var path = min[i, j] + table[i + 1, j];
						if (min[i + 1, j] > path)
							min[i + 1, j] = path;
					}

					if (j != length - 1)
					{
						var path = min[i, j] + table[i, j + 1];
						if (min[i, j + 1] > path)
							min[i, j + 1] = path;
					}
				}
			}

			for (var i = 0; i < length; i++)
			{
				for (var j = 0; j < length; j++)
					result[i, j] = '.';
			}

			result[length - 1, length - 1] = '#';

			for (int i = length - 1, j = length - 1; j != 0 || i != 0;)
			{
				if (i != 0)
				{
					if (min[i, j] == min[i - 1, j] + table[i, j])
					{
						i--;
						result[i, j] = '#';
						continue;
					}
				}

				if (j != 0)
				{
					if (min[i, j] == min[i, j - 1] + table[i, j])
					{
						j--;
						result[i, j] = '#';
					}
				}
			}
		}
	}
}