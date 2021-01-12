using System;

namespace RSPO.dotNet
{
    /// <summary>
    /// IDK WHY HELP
    /// Class for represent ONE function - Power
    /// </summary>
    public static class PowMath
    {
        /// <summary>
        /// Powers one <see cref="double"/> number on <see cref="int"/>
        /// </summary>
        /// <param name="A">The number which will be powered</param>
        /// <param name="N">The number - pow measure</param>
        /// <returns>The result of Pow</returns>
        public static double Pow(double A, int N) => Math.Pow(A, N);
    }
}
