#region Using namespaces

using RSPO.Library._8;

#endregion

namespace RSPO.Console._8
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var matrix = new[,]
			             {
				             {100, 19, 58, 1},
				             {10, 3, 1, 19},
				             {100, 5, 13, 86},
				             {10, 15, 39, 5}
			             };

			var maxSteps = new MaxSteps();
			maxSteps.CalculateStepsCount(matrix, 0, 3, 100, 0);
			System.Console.WriteLine(maxSteps.MaxStepsCount);
		}
	}
}