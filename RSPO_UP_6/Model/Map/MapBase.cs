using System.Collections.Generic;
namespace RSPO_UP_6.Model.Map
{
    public abstract class MapBase : IMap
    {
        private List<(int, int)> _freeCells;
        public bool[,] Map { get; }
        public abstract int Size { get;}
        public bool IsCellFree(int row, int column)
        {
            if (row >= Size || row < 0 ||
                column >= Size || column < 0) return false;

            return _freeCells.Exists(x => x.Item1 == row && x.Item2 == column);
        }

        protected MapBase(bool[,] matrix)
        {
            Map = new bool[Size, Size];
            _freeCells = new List<(int, int)>();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Map[i, j] = matrix[i, j];
                    if (!Map[i, j])
                        _freeCells.Add((i, j));
                }
            }
        }
    }
}
