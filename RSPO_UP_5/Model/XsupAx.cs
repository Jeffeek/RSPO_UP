using System;

namespace RSPO_UP_5.Model
{
    public class XsupAx : EqualationBase
    {
        public override double Calculate(double x, double c)
        {
            return Math.Pow(x, c) - x;
        }
    }
}
