#region Using namespaces

using System.Collections.Generic;
using OxyPlot;

#endregion

namespace RSPO_UP_5.Model
{
	public interface IIntegralFunc
	{
		IEnumerable<DataPoint> Solve(double lower, double upper, double step = 0.1d, params double[] k);
		double Calculate(double x, params double[] k);
	}
}