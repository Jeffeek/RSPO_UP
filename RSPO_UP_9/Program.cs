using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using RSPO_UP_9.Geometry;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9
{
	static class Program
    {
	    // 3 ий вариант
	    static void Main(string[] args)
	    {
			RectangleGroundsIntersection();
		    CircleSquareOrder();
		    TrianglePoints();

		    Console.ReadLine();
	    }


		// Дан прямоугольник его пересекают произвольным количеством прямых
	    //параллельных боковой стороне, так, что делят на прямоугольники.Найти точки
	    //пересечения оснований прямоугольника с прямыми.
	    private static void RectangleGroundsIntersection()
	    {
		    var rectangleStraights = new[]
		                             {
			                             new Straight(-12, 20, 20, 20),
			                             new Straight(20, 20, 20, -4),
			                             new Straight(20, -4, -12, -4),
			                             new Straight(-12, -4, -12, 20)
		                             };
		    var rectangle = new Rectangle(rectangleStraights);
		    var negativeStraights = new[]
		                            {
			                            new Straight(-20, 25, -20, -25),
			                            new Straight(28, 22, 28, -22)
		                            };
		    var positiveStraights = new[]
		                            {
			                            new Straight(-3, 29, -3, -18),
			                            new Straight(15, 30, 15, -24)
		                            };

		    var negative = rectangle.GroundParallelIntersectionPoints(negativeStraights)?.ToArray();
		    rectangle.GroundParallelIntersectionPoints(positiveStraights)
		             .ToList()
		             .ForEach(x => Console.WriteLine(x));
	    }

		//Дано множество точек на плоскости. Указать в нём три такие точки,
		//чтобы треугольник с вершинами в этих точках имел наименьшую площадь и находился в
	    //нижней полуплоскости.
	    private static void TrianglePoints()
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

		    Console.WriteLine(minSquare);
	    }

		//Дано множество точек на плоскости. Задать(первая точка центра, вторая
		//определяет длину радиуса) через каждые две подряд идущие(последнюю соединить с
	    //первой) точки окружность.И отсортировать их по возрастанию площадей,
		//образовавшихся кругов.

		private static void CircleSquareOrder()
	    {
		    var circlePoints = new List<Point>();
		    var circles = new List<Circle>();
		    var rnd = new Random();

		    for (var i = 0; i < 100; i++)
			    circlePoints.Add(new Point(rnd.Next(-20, 20), rnd.Next(-20, 20)));
		    for (var i = 0; i < 50; i++)
			    circles.Add(new Circle(circlePoints[i],
			                           circlePoints[i + 1]));

		    circles.OrderBy(x => x.Square).ToList().ForEach(Console.WriteLine);
	    }
    }
}
