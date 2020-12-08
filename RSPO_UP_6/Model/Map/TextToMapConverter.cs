using System;
using System.Text.RegularExpressions;

namespace RSPO_UP_6.Model.Map
{
    //1 - блок есть
    //0 - блока нет
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
            if (!regex.IsMatch(text))
                throw new Exception("bad map");
            var rows = regex.Split(text);
            bool[,] matrix = new bool[rows.Length, rows.Length];
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (rows[i][j] == '1')
                        matrix[i, j] = true;
                }
            }

            return matrix;
        }
    }
}
