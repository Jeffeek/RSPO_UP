#region Using namespaces

using System.Collections.Generic;
using System.Linq;
using CyberMath.Extensions.Int32;
using CyberMath.Structures.Matrices.Extensions;
using CyberMath.Structures.Matrices.Matrix;

#endregion

namespace RSPO_UP_12
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			//1
			//int[] arr = {1, 2, 3, 4, 5};
			//var sum = Sum(arr);

			//2
			//var A = new Matrix<int>(5, 2);
			//A.FillRandomly(0, 10);
			//var B = A.Select(x => x.Aggregate((acc, item) => acc * item)).ToArray();

			//3
			//      var text = File.ReadAllLines($"{Directory.GetCurrentDirectory()}\\jaggedMatrix.txt");
			//      var jaggedMatrix = new JuggedMatrix<int>(text.Length, text.Select(x => x.Split().Length));
			//jaggedMatrix.FillRandomly();
			//      var answers = jaggedMatrix.Select((x, i) => i % 2 != 0 ? x.Where(_ => _ > 0).Max() : -1)
			//                                .Where(x => x < 0)
			//                                .Average();

			//4
			//var converter = new PostfixToInfixConverter();
			//var input = "xy+v*ut*";
			//Console.WriteLine(converter.Convert(input));

			//5
			//var matrix = new Matrix<int>(10, 10);
			//matrix.FillRandomly();
			//var matrixOrderByCountOfEven = matrix.OrderBy(x => x.Count(_ => _ % 2 == 0)).Select(x => x.ToArray()).ToArray();
			//for (var i = 0; i < matrixOrderByCountOfEven.Length; i++)
			//{
			//	for (var j = 0; j < matrixOrderByCountOfEven[i].Length; j++)
			//	{
			//		Console.Write(matrixOrderByCountOfEven[i][j] + " ");
			//	}

			//	Console.WriteLine();
			//}

			//Console.WriteLine(0 % 2 == 0);

			//6
			var matrix = new Matrix<int>(3, 3);
			matrix.FillRandomly();
			for (var i = 0; i < matrix.ColumnsCount; i++)
			{
				for (var j = 0; j < matrix.RowsCount; j++)
				{
					if (matrix[j, i] >= 0 &&
					    matrix[j, i].IsPrime() &&
					    i != matrix.ColumnsCount - 1)
					{
						var unused = matrix.Select(x => x.ElementAt(j)).Min();

						break;
					}
				}
			}
		}

		private static int Sum(int[] array) => InternalSumRecursion(array, 0, 0);

		private static int InternalSumRecursion(IReadOnlyList<int> array, int index, int sum)
		{
			if (index == array.Count) return sum;
			sum += array[index];
			index++;
			return InternalSumRecursion(array, index, sum);
		}
	}
}