using System;

namespace RSPO_UP_5.Model
{
    public class XsupAminusx : EquationBase
    {
        public override double Calculate(double x, double a)
        {
            return Math.Pow(x, a) - x;
        }
    }
}
