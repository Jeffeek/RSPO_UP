#region Using namespaces

using System;

#endregion

namespace RSPO_UP_9.Geometry.Fundamental
{
	public struct Point : IEquatable<Point>
	{
		/// <inheritdoc />
		public override string ToString() => $"({nameof(X)}: {X}, {nameof(Y)}: {Y})";

		public double X { get; }
		public double Y { get; }

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static double Length(Point first, Point second) => Math.Sqrt(Math.Pow(second.X - first.X, 2) +
		                                                                    Math.Pow(second.Y - first.Y, 2));

		#region Equality members

		/// <inheritdoc />
		// ReSharper disable once CompareOfFloatsByEqualityOperator
		public bool Equals(Point other) => X == other.X && Y.Equals(other.Y);

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (obj.GetType() != GetType()) return false;
			return Equals((Point) obj);
		}

		/// <inheritdoc />
		public override int GetHashCode() => HashCode.Combine(X, Y);

		#endregion
	}
}