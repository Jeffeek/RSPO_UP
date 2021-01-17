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
			var x = -((First.X * Second.Y - Second.X * First.Y) *
			            (other.Second.X - other.First.X) -
			            (other.First.X * other.Second.Y -
			             other.Second.X *
			             other.First.Y) *
			            (Second.X - First.X)) /
			          ((First.Y - Second.Y) *
			           (other.Second.X - other.First.X) -
			           (other.First.Y -
			            other.Second.Y) *
			           (Second.X - First.X));

			var y = ((other.First.Y - other.Second.Y) *
			           -x -
			           (other.First.X * other.Second.Y -
			            other.Second.X *
			            other.First.Y)) /
			          (other.Second.X - other.First.X);
			return new Point(x, y);
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
