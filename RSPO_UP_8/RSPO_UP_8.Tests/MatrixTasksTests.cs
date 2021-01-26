#region Using namespaces

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSPO.Library._8;

#endregion

namespace RSPO_UP_8.Tests
{
	[TestClass]
	public class MatrixTasksTests
	{
		[TestMethod]
		public void CreateColumnedMatrix_test_positive()
		{
			var columnsItems = new[] {1, 2, 3};
			var expected = new[,]
			               {
				               {1, 1, 1},
				               {2, 2, 2},
				               {3, 3, 3}
			               };

			var actual = new MatrixTasks().CreateColumnedMatrix(3, 3, columnsItems);
			for (var i = 0; i < 3; i++)
			{
				for (var j = 0; j < 3; j++) Assert.IsTrue(expected[i, j] == actual[i, j]);
			}
		}

		[TestMethod]
		public void CreateColumnedMatrix_test_negative()
		{
			var columnsItems = new[] {1, 2, 3, 4};
			Assert.ThrowsException<ArgumentException>(() =>
				                                          new MatrixTasks()
					                                          .CreateColumnedMatrix(3, 3, columnsItems));
		}

		[TestMethod]
		public void GetIndexesNearAvg_test()
		{
			var matrix = new[,]
			             {
				             {53, 19, 11},
				             {98, 3, 13},
				             {39, 100, 50}
			             };

			var expected = (2, 0);
			var actual = new MatrixTasks().GetIndexesNearAvg(matrix);
			Assert.IsTrue(expected.Item1 == actual.Item1 && expected.Item2 == actual.Item2);
		}

		[TestMethod]
		public void GetMaxSteps_test()
		{
			var matrix = new[,]
			             {
				             {20, 20, 20},
				             {20, 20, 1000},
				             {20, 5, 1000}
			             };

			var maxSteps = new MaxSteps();
			maxSteps.CalculateStepsCount(matrix, 0, 2, 100, 0);
			var steps = maxSteps.MaxStepsCount;
			Assert.AreEqual(steps, 5);
		}
	}
}