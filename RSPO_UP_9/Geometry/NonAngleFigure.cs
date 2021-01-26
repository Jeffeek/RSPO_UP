#region Using namespaces

using RSPO_UP_9.Geometry.Fundamental;

#endregion

namespace RSPO_UP_9.Geometry
{
	public abstract class NonAngleFigure : FigureBase
	{
		protected NonAngleFigure(params Point[] points) : base(points) { }
	}
}