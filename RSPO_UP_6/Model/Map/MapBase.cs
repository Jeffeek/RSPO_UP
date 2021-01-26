#region Using namespaces

using System.Collections.Generic;

#endregion

namespace RSPO_UP_6.Model.Map
{
	public abstract class MapBase : IMap
	{
		private readonly List<(int, int)> _freeCells;

		protected MapBase(bool[,] matrix)
		{
			Map = new bool[Size, Size];
			_freeCells = new List<(int, int)>();
			for (var i = 0; i < Size; i++)
			{
				for (var j = 0; j < Size; j++)
				{
					Map[i, j] = matrix[i, j];
					if (!Map[i, j])
						_freeCells.Add((i, j));
				}
			}
		}

		public bool[,] Map { get; }
		public abstract int Size { get; }

		public bool IsCellFree(int row, int column)
		{
			if (row >= Size ||
			    row < 0 ||
			    column >= Size ||
			    column < 0) return false;

			return _freeCells.Exists(x => x.Item1 == row && x.Item2 == column);
		}
	}
}