using System;

namespace RSPO_UP_5.Model
{
    public class SinXminusA : EquationBase
    {
        public  override double Calculate(double x, double a)
        {
            return Math.Sin(x - a);
        }
    }
}
