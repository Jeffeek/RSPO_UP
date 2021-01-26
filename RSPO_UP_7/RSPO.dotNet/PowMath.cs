#region Using namespaces

using System;

#endregion

namespace RSPO.dotNet
{
	/// <summary>
	///     IDK WHY HELP
	///     Class for represent ONE function - Power
	/// </summary>
	public static class PowMath
	{
		/// <summary>
		///     Powers one <see cref="double" /> number on <see cref="int" />
		/// </summary>
		/// <param name="a">The number which will be powered</param>
		/// <param name="n">The number - pow measure</param>
		/// <returns>The result of Pow</returns>
		public static double Pow(double a, int n) => Math.Pow(a, n);
	}
}