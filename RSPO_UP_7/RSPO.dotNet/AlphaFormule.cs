#region Using namespaces

using System;

#endregion

namespace RSPO.dotNet
{
	/// <summary>
	///     Presents the ALPHA-HYPER-CYBER formule
	/// </summary>
	public class AlphaFormule
	{
		/// <summary>Initializes a new instance of the <see cref="T:RSPO.dotNet.AlphaFormule" /> class.</summary>
		public AlphaFormule(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		///     The X argument
		/// </summary>
		public double X { get; }

		/// <summary>
		///     The Y argument
		/// </summary>
		public double Y { get; }

		/// <summary>
		///     The Z argument
		/// </summary>
		public double Z { get; }

		/// <summary>
		///     Calculates the expression with the defined properties <seealso cref="X" />
		/// <seealso cref="Y"/> <seealso cref="Z" />
		/// </summary>
		/// <returns>Calculated value</returns>
		public double Calculate() => Math.Log(Math.Pow(Y, -Math.Sqrt(Math.Abs(X)))) *
		                             (X - Y / 2) +
		                             Math.Pow(Math.Sin(Math.Atan(Z)), 2);
	}
}