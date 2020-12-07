using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSPO_UP_6.Model.Map
{
    public static class TextToMapConverter
    {
        public static IMap Convert(string text)
        {
            IMap map;
            var matrix = ConvertToBoolMatrix(text);
            int size = matrix.GetLength(0);
            switch (size)
            {
                case 6:
                    map = new Map6X6(matrix);
                    break;
                case 8:
                    map = new Map8X8(matrix);
                    break;
                case 10:
                    map = new Map10X10(matrix);
                    break;
                default:
                    throw new NullReferenceException();
            }

            return map;
        }

        public static bool[,] ConvertToBoolMatrix(string text)
        {
            var regex = new Regex("\r\n");
            var rows = regex.Split(text);
            bool[,] matrix = new bool[rows.Length, rows.Length];
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rows[i][j] == '0';
                }
            }

            return matrix;
        }
    }
}
