using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSPO.Library._8;

namespace RSPO_UP_8.Tests
{
    [TestClass]
    public class TableTasksTests
    {
        [TestMethod]
        public void ShortWay_test()
        {
	        var table = new[,]
	                    {
		                    {9, 2, 9},

		                    {3, 2, 1},

		                    {0, 0, 1}
	                    };

	        var expected = new[,]
	                       {
		                       {'#', '.', '.'},
		                       {'#', '.', '.'},
		                       {'#', '#', '#'}
	                       };

	        new TableTasks().ShortWay(table, out var chars);
			CollectionAssert.AreEqual(expected, chars);
        }
    }
}
