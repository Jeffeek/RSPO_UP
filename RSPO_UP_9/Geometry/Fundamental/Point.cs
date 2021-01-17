using System;

namespace RSPO_UP_9.Geometry.Fundamental
{
    public struct Point : IEquatable<Point>
    {
	    public double X { get; private set; }
	    public double Y { get; private set; }

	    public Point(double x, double y)
	    {
		    X = x;
		    Y = y;
	    }

		public static double Length(Point first, Point second) => Math.Sqrt(Math.Pow(second.X - first.X, 2) + 
		                                                                      Math.Pow(second.Y - first.Y, 2));
		
		

		#region Equality members

		/// <inheritdoc />
		public bool Equals(Point other) => X == other.X && Y == other.Y;

	    /// <inheritdoc />
	    public override bool Equals(object obj)
	    {
		    if(ReferenceEquals(null, obj)) return false;
		    if(obj.GetType() != this.GetType()) return false;
		    return Equals((Point) obj);
	    }

	    /// <inheritdoc />
	    public override int GetHashCode() => HashCode.Combine(X, Y);

	    #endregion
    }
}
