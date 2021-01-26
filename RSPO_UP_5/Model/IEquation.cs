#region Using namespaces

using System.Collections.Generic;
using OxyPlot;

#endregion

namespace RSPO_UP_5.Model
{
	public interface IEquation
	{
		double? Root { get; }
		IEnumerable<DataPoint> Solve(double lower, double upper, double a = 0d, double step = 0.1d);
		double Calculate(double x, double a);
	}
}