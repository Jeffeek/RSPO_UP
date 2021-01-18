using System;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
    public class Circle : NonAngleFigure
    {
	    private const int StraightsCount = 1;
		public Point CenterPoint { get; }
	    public double Radius { get; }
	    public double Diameter { get; }
	    
	    public Circle(Point centerPoint, int radius) : base(centerPoint)
	    {
		    CenterPoint = centerPoint;
		    Radius = radius;
		    Diameter = Radius * 2;
		    Square = Math.PI * Math.Pow(Radius, 2);
		    Perimeter = 2 * Math.PI * Radius;
	    }

	    #region Overrides of FigureBase

	    /// <inheritdoc />
	    public override bool ArePointsValid(params Point[] straights) => true;

	    #endregion
    }
}
