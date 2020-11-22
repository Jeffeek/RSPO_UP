using System;

namespace RSPO_UP_5.Model
{
    public class AsupX : EquationBase
    {
        public override double Calculate(double x, double a)
        {
            return Math.Pow(a, x);
        }
    }
}
