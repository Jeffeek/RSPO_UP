using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using RSPO_UP_9.Geometry;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9
{
    [SuppressMessage("ReSharper", "ArrangeTypeModifiers")]
    static class Program
    {
	    // ReSharper disable once ArrangeTypeMemberModifiers
	    static void Main(string[] args)
	    {
		    
		    TrianglePoints();

		    Console.ReadLine();
	    }

	    static void TrianglePoints()
	    {
		    var trianglePoints = new List<Point>();
		    var rnd = new Random();

		    for (var i = 0; i < 30; i++)
			    trianglePoints.Add(new Point(rnd.Next(-50, 40), rnd.Next(-50, 40)));
		    var minSquare = double.MaxValue;
		    for(var i = 0; i < 5; i++)
		    {
			    var triangle = new Triangle(new Straight(trianglePoints[i], trianglePoints[i + 1]),
			                                new Straight(trianglePoints[i + 1], trianglePoints[i + 2]),
			                                new Straight(trianglePoints[i + 2], trianglePoints[i]));

			    if(triangle.Square < minSquare &&
			       triangle.Straights.All(x => x.First.Y < 0 && x.Second.Y < 0))
				    minSquare = triangle.Square;
		    }
	    }

	    static void CircleSquareOrder()
	    {
		    var circlePoints = new List<Point>();
		    var circles = new List<Circle>();
		    var rnd = new Random();

		    for (var i = 0; i < 10; i++)
			    circlePoints.Add(new Point(rnd.Next(-20, 20), rnd.Next(-20, 20)));
		    for (var i = 0; i < 5; i++)
			    circles.Add(new Circle(circlePoints[i], circlePoints[i + 1]));

		    circles = circles.OrderBy(x => x.Square).ToList();
		}
    }
}
