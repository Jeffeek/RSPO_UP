using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_6.Model.Map
{
    public class Map8X8 : IMap
    {
        public bool[,] Map { get; }

        public int Size { get; } = 8;

        public Map8X8(bool[,] matrix)
        {
            Map = new bool[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Map[i, j] = matrix[i, j];
                }
            }
        }
    }
}
