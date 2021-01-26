#region Using namespaces

using System.Linq;
using RSPO_UP_9.Geometry.Fundamental;

#endregion

namespace RSPO_UP_9.Geometry
{
	public abstract class AngleFigure : FigureBase
	{
		protected AngleFigure(params Straight[] straights) : base(straights.Select(x => x.First)
		                                                                   .Concat(straights.Select(x => x.Second))
		                                                                   .ToArray())
		{
			Straights = straights;
			Perimeter = Straights.Sum(x => x.Length);
			HalfPerimeter = Perimeter / 2;
		}

		protected AngleFigure(params Point[] points) : base(points) { }
		public Straight[] Straights { get; }
	}
}