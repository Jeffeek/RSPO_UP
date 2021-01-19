using RSPO.Library._8;

namespace RSPO.Console._8
{
    internal class Program
    {
	    private static void Main(string[] args)
	    {
			var matrix = new[,]
			             {
				             {10, 20, 20},
				             {10, 1000, 1000},
				             {30, 5, 5}
			             };

			var maxSteps = new MaxSteps();
			maxSteps.StepsCount(matrix, 0, 2, 200, 0);
			int steps = MaxSteps._stepsCount;
			System.Console.WriteLine(steps);
		}
    }
}
