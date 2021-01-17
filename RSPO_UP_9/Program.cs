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
            var rectStraights = new Straight[]
                                {
                                    new Straight(-10, 10, 10, 10),
                                    new Straight(10, 10, 10, -10),
                                    new Straight(10, -10, -10, -10),
                                    new Straight(-10, -10, -10, 10)
                                };

            var rect = new Rectangle(rectStraights);
            var circle = new Circle(new Straight(-11, 5, -11, 5), 3);
            var res = rect.IsIntersectsWith(circle);
			
			Console.ReadLine();
	    }
    }
}
