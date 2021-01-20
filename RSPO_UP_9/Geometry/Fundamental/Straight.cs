using System;

namespace RSPO_UP_9.Geometry.Fundamental
{
    public struct Straight : IEquatable<Straight>
    {
	    public Point First { get; }
        public Point Second { get; }
        public double Length { get; }

        public Straight(Point first, Point second)
	    {
		    First = first;
		    Second = second;
		    Length = Point.Length(first, second);
	    }

        public Straight(int x1, int y1, int x2, int y2)
        {
	        First = new Point(x1, y1);
	        Second = new Point(x2, y2);
	        Length = Point.Length(First, Second);
        }

		public Point IntersectionWith(Straight other)
		{
			double xo = First.X,
			       yo = First.Y;

			double p = Second.X - First.X,
			       q = Second.Y - First.Y;

			double x1 = other.First.X,
			       y1 = other.First.Y;
			double p1 = other.Second.X - other.First.X,
			       q1 = other.Second.Y - other.First.Y;

			var x = (xo * q * p1 - x1 * q1 * p - yo * p * p1 + y1 * p * p1) /
			        (q * p1 - q1 * p);
			var y = (yo * p * q1 - y1 * p1 * q - xo * q * q1 + x1 * q * q1) /
			        (p * q1 - p1 * q);

			return new Point(x, y);
		}

		public static bool IsIntersectsWith(Straight first, Straight second)
        {
	        double x1 = first.First.X, y1 = first.First.Y,
	               x2 = first.Second.X, y2 = first.Second.Y,
	               x3 = second.First.X, y3 = second.First.Y,
	               x4 = second.Second.X, y4 = second.Second.Y;

	        var denominator = (y4 - y3) * (x1 - x2) - (x4 - x3) * (y1 - y2);
	        if (denominator == 0)
	        {
		        return (x1 * y2 - x2 * y1) * (x4 - x3) -
		               (x3 * y4 - x4 * y3) * (x2 - x1) == 0 &&
		               (x1 * y2 - x2 * y1) * (y4 - y3) -
		               (x3 * y4 - x4 * y3) * (y2 - y1) == 0;
	        }

	        var numerator_a = (x4 - x2) * (y4 - y3) - (x4 - x3) * (y4 - y2);
	        var numerator_b = (x1 - x2) * (y4 - y2) - (x4 - x2) * (y1 - y2);
	        var Ua = numerator_a / denominator;
	        var Ub = numerator_b / denominator;

	        return Ua >= 0 && Ua <= 1 && Ub >= 0 && Ub <= 1;
        }
		

		#region Equality members

		/// <inheritdoc />
		public bool Equals(Straight other) => Equals(First, other.First) && Equals(Second, other.Second) && Length == other.Length;

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
	        if(ReferenceEquals(null, obj)) return false;
	        if(obj.GetType() != this.GetType()) return false;
	        return Equals((Straight) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(First, Second, Length);

        #endregion
    }
}
