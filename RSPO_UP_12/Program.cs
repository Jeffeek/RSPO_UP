using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using СyberMath.Structures.Matrices.Extensions;
using СyberMath.Structures.Matrices.Matrix;
using СyberMath.Structures.Matrices;
using СyberMath.Structures.Matrices.JaggedMatrix;

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
	        var text = File.ReadAllLines($"{Directory.GetCurrentDirectory()}\\jaggedMatrix.txt");
	        var matrix = new int[text.Length][];
	        for(var i = 0; i < text.Length; i++)
		        matrix[i] = new int[text[i].Split().Length];
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
