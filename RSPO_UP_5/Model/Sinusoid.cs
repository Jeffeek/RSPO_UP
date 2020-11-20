using System;

namespace RSPO_UP_5.Model
{
    public class Sinusoid : EqualationBase
    {
        public  override double Calculate(double x, double c)
        {
            return Math.Sin(x - c);
        }
    }
}
