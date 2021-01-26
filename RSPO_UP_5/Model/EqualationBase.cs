#region Using namespaces

using System.Collections.Generic;
using MahApps.Metro.Controls;
using OxyPlot;

#endregion

namespace RSPO_UP_5.Model
{
	public abstract class EquationBase : IEquation
	{
		public IEnumerable<DataPoint> Solve(double lower, double upper, double a = 0, double step = 0.1)
		{
			var dataPoints = new List<DataPoint>();
			for (; lower < upper; lower += step)
			{
				var pointX = lower;
				var pointY = Calculate(lower, a);
				var point = new DataPoint(pointX, pointY);
				if (pointY.IsCloseTo(0.0d))
					Root = pointX;

				dataPoints.Add(point);
			}

			return dataPoints;
		}

		public abstract double Calculate(double x, double a);

		public double? Root { get; private set; }
	}
}