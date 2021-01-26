#region Using namespaces

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSPO.Library._8;

#endregion

namespace RSPO_UP_8.Tests
{
	[TestClass]
	public class ArrayTasksTests
	{
		[TestMethod]
		public void IncreaseOnFirstOdd_test_positive()
		{
			var testArr = new[] {2, 4, 5, 7, 11, 15, 16};
			var expected = new[] {2, 4, 10, 12, 16, 20, 16};
			var actual = new ArrayTasks().IncreaseOnFirstOdd(testArr);
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void IncreaseOnFirstOdd_test_negative()
		{
			var testArr = new[] {2, 4, 6, 8, -4, 16, 16};
			var expected = new[] {2, 4, 6, 8, -4, 16, 16};
			var actual = new ArrayTasks().IncreaseOnFirstOdd(testArr);
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}