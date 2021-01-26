#region Using namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using RSPO_UP_9.Geometry.Fundamental;

#endregion

namespace RSPO_UP_9.Geometry
{
	public class Rectangle : AngleFigure
	{
		private const int StraightsCount = 4;

		public Rectangle(params Straight[] straights) : base(straights)
		{
			Square = Straights[0].Length * Straights[1].Length;
			InnerRadius = Straights[0].Length / 2;
			OuterRadius = Math.Sqrt(Math.Pow(Straights[3].Length, 2) +
			                        Math.Pow(Straights[0].Length, 2)) /
			              2;

			Diagonal = Point.Length(straights[0].First, straights[1].Second);
		}

		public double InnerRadius { get; }
		public double OuterRadius { get; }
		public double Diagonal { get; }

		public override bool ArePointsValid(params Point[] points)
		{
			if (points.Length != StraightsCount * 2) return false;
			var diagonal1 = Point.Length(points[0], points[2]);
			var diagonal2 = Point.Length(points[1], points[3]);
			return Math.Abs(diagonal1 - diagonal2) < 0.0000000000001;
		}

		/// <summary>
		///     Возвращает две площади, которые остаются после вставки треугольника в прямоугольник
		/// </summary>
		/// <param name="triangle"></param>
		/// <returns></returns>
		public (double, double) InsertTriangle(Triangle triangle)
		{
			//TODO: проверить входные данные
			var firstTrianglePieces = new[]
			                          {
				                          new Straight(Straights[3].First, Straights[3].Second),
				                          new Straight(Straights[3].Second, triangle.Straights[1].First),
				                          new Straight(triangle.Straights[1].First, Straights[3].First)
			                          };

			var secondTrianglePieces = new[]
			                           {
				                           new Straight(triangle.Straights[0].Second, Straights[0].Second),
				                           new Straight(Straights[0].Second, Straights[1].Second),
				                           new Straight(Straights[1].Second, triangle.Straights[0].Second)
			                           };

			var first = new Triangle(firstTrianglePieces);
			var second = new Triangle(secondTrianglePieces);
			return (first.Square, second.Square);
		}

		/// <summary>
		///     Принимает в себя коллекцию параллельных прямых боковым сторонам прямоугольника
		///     Возвращает 2 точки: верхняя точка пересечения и вторая точка пересечения нижнего основания
		/// </summary>
		/// <param name="straights"></param>
		/// <returns></returns>
		public IEnumerable<(Point, Point)> GroundParallelIntersectionPoints(IEnumerable<Straight> straights)
		{
			var straightsAsArray = straights as Straight[] ?? straights.ToArray();
			foreach (var line in straightsAsArray.Where(line => Straight.IsIntersectsWith(line, Straights[0]) &&
			                                                    Straight.IsIntersectsWith(line, Straights[2])))
			{
				yield return (Straights[0].IntersectionWith(line),
				              Straights[2].IntersectionWith(line));
			}
		}

		/// <summary>
		///     Проверка того если круг пересекается с прямоугольником
		/// </summary>
		/// <param name="circle"></param>
		/// <returns></returns>
		public bool IsIntersectsWith(Circle circle)
		{
			var halfWidth = Straights[0].Length / 2;
			var halfHeight = Straights[1].Length / 2;
			var rectangleCenter = Straights[2].Second;
			var cx = Math.Abs(circle.CenterPoint.X - rectangleCenter.X - halfWidth);
			var xDist = halfWidth + circle.Radius;
			if (cx > xDist)
				return false;

			var cy = Math.Abs(circle.CenterPoint.Y - rectangleCenter.Y - halfHeight);
			var yDist = halfHeight + circle.Radius;
			if (cy > yDist)
				return false;

			if (cx <= halfWidth ||
			    cy <= halfHeight)
				return true;

			var xCornerDist = cx - halfWidth;
			var yCornerDist = cy - halfHeight;
			var xCornerDistSq = xCornerDist * xCornerDist;
			var yCornerDistSq = yCornerDist * yCornerDist;
			var maxCornerDistSq = circle.Radius * circle.Radius;
			return xCornerDistSq + yCornerDistSq <= maxCornerDistSq;
		}
	}
}