using System;
using System.Collections.Generic;
using System.Text;
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
		                    {9, 4, 3},

		                    {2, 1, 6},

		                    {0, 9, 1}
	                    };

	        var expected = new char[,]
	                       {
		                       {'#', '.', '.'},
		                       {'#', '#', '#'},
		                       {'.', '.', '#'}
	                       };

	        new TableTasks().ShortWay(table, out var chars);
			CollectionAssert.AreEqual(expected, chars);
        }
    }
}
