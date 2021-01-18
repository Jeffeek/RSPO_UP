using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
    public abstract class NonAngleFigure : FigureBase
    {
	    protected NonAngleFigure(params Point[] points) : base(points) { }
    }
}
