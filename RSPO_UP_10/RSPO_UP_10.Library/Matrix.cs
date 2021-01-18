using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RSPO_UP_10.Library
{
    public class Matrix
    {
        private readonly int[,] _innerMatrix;

        public Matrix(int rowsCount, int columnsCount)
        {
	        var rnd = new Random();
	        _innerMatrix = new int[rowsCount, columnsCount];
            for(var i = 0; i < _innerMatrix.GetLength(0); i++)
            {
	            for (var j = 0; j < _innerMatrix.GetLength(1); j++)
	            {
		            _innerMatrix[i, j] = rnd.Next(1, 15);
	            }
            }
        }

        public Matrix(string path)
        {
	        if(!File.Exists(path)) throw new FileNotFoundException(nameof(path));
	        var matrix = File.ReadAllLines(path).Select(row => row.Split().Select(int.Parse).ToArray()).ToArray();
	        _innerMatrix = new int[matrix.Length, matrix[0].Length];
	        for (var i = 0; i < _innerMatrix.GetLength(0); i++)
	        {
		        for (var j = 0; j < _innerMatrix.GetLength(1); j++)
		        {
			        _innerMatrix[i, j] = matrix[i][j];
		        }
	        }
        }

        public static bool operator >=(Matrix first, Matrix second)
        {
	        var firstMatrixDiagonal = first.DiagonalPrimeSum();
	        var secondMatrixDiagonal = second.DiagonalPrimeSum();
	        return firstMatrixDiagonal >= secondMatrixDiagonal;
        }

        public static bool operator <=(Matrix first, Matrix second)
        {
	        var firstMatrixDiagonal = first.DiagonalPrimeSum();
	        var secondMatrixDiagonal = second.DiagonalPrimeSum();
	        return firstMatrixDiagonal <= secondMatrixDiagonal;
		}

        public int DiagonalPrimeSum()
        {
            var sum = 0;
	        for(var i = 0; i < _innerMatrix.GetLength(0); i++)
	        {
		        if(_innerMatrix[i, i].IsPrime())
			        sum += _innerMatrix[i, i];
	        }

	        return sum;
        }
    }
}
