using System;
using System.Collections.Generic;
using System.Text;

namespace RSPO_UP_10.Library
{
    public class ComplexNumber
    {
	    public const int iSquare = -1;
        public double Real { get; }
        public double Virtual { get; }

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

        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second)
        {
	        var real = first.Real * second.Real - first.Virtual * second.Virtual;
            var vir = first.Real * second.Virtual + second.Real * first.Virtual;
            return new ComplexNumber(real, vir);
        }

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString() => $"{Real} {(Virtual < 0 ? String.Empty : "+")} {Virtual}i";

        #endregion
    }
}
