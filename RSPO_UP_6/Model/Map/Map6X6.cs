using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_6.Model.Map
{
    public class Map6X6 : IMap
    {
        public bool[,] Map { get; }

        public int Size { get; }

        public Map6X6(bool[,] matrix)
        {
            Map = new bool[6,6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Map[i, j] = matrix[i, j];
                }
            }
        }
    }
}
