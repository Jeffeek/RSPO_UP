using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;

namespace RSPO_UP_5.Model
{
    public interface IIntegralFunc
    {
        IEnumerable<DataPoint> Solve(double lower, double upper, double step = 0.1d, params double[] k);
        double Calculate(double x, params double[] k);
    }
}
