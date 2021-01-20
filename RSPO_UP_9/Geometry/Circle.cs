using System;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
	public sealed class Circle : NonAngleFigure
	{
		/// <inheritdoc />
		public override string ToString() => $"{nameof(CenterPoint)}: {CenterPoint}, {nameof(Radius)}: {Radius}, {nameof(Diameter)}: {Diameter}, {nameof(Square)}: {Square}";

		private const int StraightsCount = 1;
		public Point CenterPoint { get; }
		public double Radius { get; }
		public double Diameter { get; }

		public Circle(Point centerPoint, int radius) : base(centerPoint)
		{
			CenterPoint = centerPoint;
			Radius = radius;
			Diameter = Radius * 2;
			Square = Math.PI * Math.Pow(Radius, 2);
			Perimeter = 2 * Math.PI * Radius;
		}

		public Circle(Point centerPoint, Point edgePoint) : base(centerPoint, edgePoint)
		{
			CenterPoint = centerPoint;
			Radius = Point.Length(centerPoint, edgePoint);
			Diameter = Radius * 2;
			Square = Math.PI * Math.Pow(Radius, 2);
			Perimeter = 2 * Math.PI * Radius;
		}

		#region Overrides of FigureBase

		/// <inheritdoc />
		public override bool ArePointsValid(params Point[] points) => points.Length == 1 || points.Length == 2;

		#endregion

		#region Overrides of Object

		

		#endregion
	}
}
