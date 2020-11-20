using System.Collections.Generic;
using OxyPlot;

namespace RSPO_UP_5.Model
{
    public interface IEqualation
    {
        IEnumerable<DataPoint> Solve(double lower, double upper, double c = 0d, double step=0.1d);
        double Calculate(double x, double c);
        double? Root { get; }
    }
}
