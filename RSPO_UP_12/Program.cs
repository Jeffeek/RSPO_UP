using CyberMath.Structures.Matrices.JaggedMatrix;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CyberMath.Structures.Matrices.Extensions;

namespace RSPO_UP_12
{
    class Program
    {
        static void Main(string[] args)
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
        }

        private static int Sum(int[] array) => InternalSumRecursion(array, 0, 0);

        private static int InternalSumRecursion(int[] array, int index, int sum)
        {
	        if(index == array.Length) return sum;
	        sum += array[index];
	        index++;
	        return InternalSumRecursion(array, index, sum);
        }
    }
}
