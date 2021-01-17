using System;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
    public class Circle : FigureBase
    {
	    private const int StraightsCount = 1;
		public Point CenterPoint { get; }
	    public double Radius { get; }
	    public double Diameter { get; }
	    
	    public Circle(Point centerPoint, int radius)
	    {
		    CenterPoint = centerPoint;
		    Radius = radius;
		    Diameter = Radius * 2;
		    Square = Math.PI * Math.Pow(Radius, 2);
		    Perimeter = 2 * Math.PI * Radius;
	    }

	    public Circle(Straight straight, int radius) : base(straight)
	    {
		    CenterPoint = straight.First;
			Radius = radius;
			Diameter = Radius * 2;
			Square = Math.PI * Math.Pow(Radius, 2);
			Perimeter = 2 * Math.PI * Radius;
		}

	    #region Overrides of FigureBase

	    /// <inheritdoc />
	    public override bool ArePointsValid(params Straight[] straights)
	    {
		    if(straights.Length != StraightsCount) return false;
		    if(straights[0].First.X != straights[0].Second.X ||
		       straights[0].First.Y != straights[0].Second.Y) return false;

		    return true;
	    }

	    #endregion
    }
}
