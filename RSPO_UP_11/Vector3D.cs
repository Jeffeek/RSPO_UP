#region Using namespaces

using System;

#endregion

namespace RSPO_UP_11
{
	public class Vector3D
	{
		public Vector3D(double x1, double y1, double z1, double x2, double y2, double z2)
		{
			A = new Point3D(x1, y1, z1);
			B = new Point3D(x2, y2, z2);
			Length = Math.Sqrt((B.X - A.X) * (B.X - A.X) +
			                   (B.Y - A.Y) * (B.Y - A.Y) +
			                   (B.Z - A.Z) * (B.Z - A.Z));
		}

		public Vector3D(Point3D a, Point3D b)
		{
			A = a;
			B = b;
			Length = Math.Sqrt((B.X - A.X) * (B.X - A.X) +
			                   (B.Y - A.Y) * (B.Y - A.Y) +
			                   (B.Z - A.Z) * (B.Z - A.Z));
		}

		public Point3D A { get; }
		public Point3D B { get; }
		public double Length { get; }

		public static Vector3D operator +(Vector3D first, Vector3D second)
		{
			var a = new Point3D(first.A.X + second.A.X,
			                    first.A.Y + second.A.Y,
			                    first.A.Z + second.A.Z);

			var b = new Point3D(first.B.X + second.B.X,
			                    first.B.Y + second.B.Y,
			                    first.B.Z + second.B.Z);

			return new Vector3D(a, b);
		}

		public static Vector3D operator -(Vector3D first, Vector3D second)
		{
			var a = new Point3D(first.A.X - second.A.X,
			                    first.A.Y - second.A.Y,
			                    first.A.Z - second.A.Z);

			var b = new Point3D(first.B.X - second.B.X,
			                    first.B.Y - second.B.Y,
			                    first.B.Z - second.B.Z);

			return new Vector3D(a, b);
		}

		public static double operator *(Vector3D first, Vector3D second) =>
			(first.B.X - first.A.X) * (second.B.X - second.A.X) +
			(first.B.Y - first.A.Y) * (second.B.Y - second.A.Y) +
			(first.B.Z - first.A.Z) * (second.B.Z - second.A.Z);

		#region Overrides of Object

		/// <inheritdoc />
		public override string ToString() => $"{nameof(A)} : {A}; {nameof(B)} : {B}";

		#endregion
	}
}