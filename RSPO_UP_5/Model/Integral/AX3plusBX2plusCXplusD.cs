#region Using namespaces

using System;
using System.Collections.Generic;
using OxyPlot;

#endregion

namespace RSPO_UP_5.Model.Integral
{
	internal class Ax3PlusBx2PlusCXplusD : IIntegralFunc
	{
		public IEnumerable<DataPoint> Solve(double lower, double upper, double step = 0.1, params double[] k)
		{
			var dataPoints = new List<DataPoint>();
			for (; lower < upper; lower += step)
			{
				var pointX = lower;
				var pointY = Calculate(lower, k);
				var point = new DataPoint(pointX, pointY);
				dataPoints.Add(point);
			}

			return dataPoints;
		}

		public double Calculate(double x, params double[] k) =>
			k[0] * Math.Pow(x, 3) + k[1] * Math.Pow(x, 2) + k[2] * x + k[3];
	}
}