using System;

namespace RSPO_UP_5.Model
{
    public class AsupX : EqualationBase
    {
        public override double Calculate(double x, double c)
        {
            return Math.Pow(c, x);
        }
    }
}
