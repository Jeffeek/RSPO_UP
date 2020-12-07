using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_6.Model.Map
{
    public class Map10X10 : IMap
    {
        public bool[,] Map { get; }

        public int Size { get; } = 10;

        public Map10X10(bool[,] matrix)
        {
            Map = new bool[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Map[i, j] = matrix[i, j];
                }
            }
        }
    }
}
