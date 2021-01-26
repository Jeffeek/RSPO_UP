#region Using namespaces

using RSPO_UP_9.Geometry.Fundamental;

#endregion

namespace RSPO_UP_9.Geometry
{
	public interface IFigure
	{
		double Square { get; }
		double Perimeter { get; }
		double HalfPerimeter { get; }
		bool ArePointsValid(params Point[] points);
	}
}