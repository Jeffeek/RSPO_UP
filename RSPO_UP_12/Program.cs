﻿#region Using namespaces

using System;
using System.Collections.Generic;
using System.IO;
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
            //var input = "ABC*EF-/+";
            //Console.WriteLine(converter.Convert(input));

            //TREE

            //var tree = new ExpressionTree("ABC*EF-/+");
            //var result = tree.Inorder();

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

            //6.1
     //       var matrix = new Matrix<int>(3, 3);
     //       matrix.FillRandomly();
     //       var ordered = matrix.OrderBy(row => row.Count(element => element.ToString().Where(Char.IsDigit).Select(ch => int.Parse(ch.ToString())).Sum() % 2 == 0));

     //       for (var i = 0; i < matrix.RowsCount; i++)
     //       {
	    //        for (var j = 0; j < matrix.ColumnsCount; j++)
	    //        {
					//Console.Write($"{matrix[i, j]}\t");
	    //        }

	    //        Console.WriteLine();
     //       }

     //       Console.WriteLine(new string('-', 30));
            
     //       foreach (var row in ordered)
     //       {
	    //        foreach (var item in row)
	    //        {
		   //         Console.Write($"{item}\t");
	    //        }
	    //        Console.WriteLine();
     //       }
            
            //6.2
   //         var matrix = new Matrix<int>(3, 3);
			//matrix.FillRandomly();

			//var listMatrix = new List<List<int>>();
			//for (var i = 0; i < matrix.RowsCount; i++)
			//	listMatrix.Add(new List<int>(matrix.ElementAt(i)));

			//var flag = false;
			//for (var i = 0; i < listMatrix[0].Count; i++)
			//{
			//	for (var j = 0; j < listMatrix.Count; j++)
			//	{
			//		if (listMatrix[j][i] > 0 && listMatrix[j][i].IsPrime())
			//		{
			//			var min = listMatrix.Select(x => x.ElementAt(i)).Min();
			//			var first = listMatrix.Select(x => x.ElementAt(i)).First();
			//			var newElement = (int) Math.Pow(min, first);
			//			listMatrix.Insert(i + 1, new List<int>(Enumerable.Range(0, listMatrix[0].Count).Select(x => 0).ToArray()));
			//			listMatrix[i + 1][j] = newElement;
			//			flag = true;
			//			break;
			//		}
					
			//	}
			//	if (flag) break;
			//}

			//for (var i = 0; i < listMatrix.Count; i++)
			//{
			//	for (var j = 0; j < listMatrix[i].Count; j++)
			//	{
			//		Console.Write($"{listMatrix[i][j]}\t");
			//	}

			//	Console.WriteLine();
			//}

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