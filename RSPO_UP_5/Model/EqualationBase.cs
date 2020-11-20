using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;

namespace RSPO_UP_5.Model
{
    public abstract class EqualationBase : IEqualation
    {
        public IEnumerable<DataPoint> Solve(double lower, double upper, double c = 0, double step = 0.1)
        {
            var dataPoints = new List<DataPoint>();
            for (; lower < upper; lower += step)
            {
                var pointX = lower;
                var pointY = Calculate(lower, c);
                var point = new DataPoint(pointX, pointY);
                if (pointY == 0.0d)
                    Root = pointX;
                dataPoints.Add(point);
            }

            return dataPoints;
        }

        public abstract double Calculate(double x, double c);

        public double? Root { get; private set; } = null;
    }
}
