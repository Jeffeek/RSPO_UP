using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using RSPO_UP_9.Geometry;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9
{
    [SuppressMessage("ReSharper", "ArrangeTypeModifiers")]
    class Program
    {
	    // ReSharper disable once ArrangeTypeMemberModifiers
	    static void Main(string[] args)
	    {
		    var point1 = new Point(-10, 0);
		    var point2 = new Point(0, 10);
			var point3 = new Point(10, 0);

			var straight1 = new Straight(point1, point2);
			var straight2 = new Straight(point2, point3);
			var straight3 = new Straight(point3, point1);

			var triangle = new Triangle(new[] {straight1, straight2, straight3});

			Console.ReadLine();
	    }
    }
}
