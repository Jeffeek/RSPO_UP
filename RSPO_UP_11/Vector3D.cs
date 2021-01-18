using System;
using System.Collections.Generic;
using System.Text;

namespace RSPO_UP_11
{
    public class Vector3D
    {
        public Point3D A { get; }
        public Point3D B { get; }
        public double Length { get; }

        public Vector3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
	        A = new Point3D(x1, y1, z1);
	        B = new Point3D(x2, y2, z2);
	        Length = Math.Sqrt(Math.Pow(A.X + B.X,2) + Math.Pow(A.Y + B.Y, 2) + Math.Pow(A.Z + B.Z, 2));
        }

        public Vector3D(Point3D a, Point3D b)
        {
	        A = a;
	        B = b;
			Length = Math.Sqrt(Math.Pow(A.X + B.X, 2) + Math.Pow(A.Y + B.Y, 2) + Math.Pow(A.Z + B.Z, 2));
		}

        public static Vector3D operator+(Vector3D first, Vector3D second)
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

        public static Vector3D operator *(Vector3D first, Vector3D second)
        {
	        var a = new Point3D(first.A.X * second.A.X,
	                          first.A.Y * second.A.Y,
	                          first.A.Z * second.A.Z);
	        var b = new Point3D(first.B.X * second.B.X,
	                          first.B.Y * second.B.Y,
	                          first.B.Z * second.B.Z);
	        return new Vector3D(a, b);
        }
	}
}
