#region Using namespaces

using System;

#endregion

namespace RSPO_UP_10.Library
{
	public sealed class ComplexNumber
	{
		public ComplexNumber(double real, double vir)
		{
			Real = real;
			Virtual = vir;
		}

		public ComplexNumber()
		{
			var rnd = new Random();
			Real = 1 + 19 * rnd.NextDouble();
			Virtual = 1 + 19 * rnd.NextDouble();
		}

		// ReSharper disable once UnusedMember.Global
		// ReSharper disable once InconsistentNaming
		public static int ISquare { get; } = -1;

		public double Real { get; }
		public double Virtual { get; }

		public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second)
		{
			var real = first.Real * second.Real - first.Virtual * second.Virtual;
			var vir = first.Real * second.Virtual + second.Real * first.Virtual;
			return new ComplexNumber(real, vir);
		}

		#region Overrides of Object

		/// <inheritdoc />
		public override string ToString() => $"{Real} {(Virtual < 0 ? string.Empty : "+")} {Virtual}i";

		#endregion
	}
}