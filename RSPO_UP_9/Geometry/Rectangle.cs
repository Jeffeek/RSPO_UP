using System;
using System.Collections.Generic;
using System.Linq;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
    public class Rectangle : IFigure
    {
		private const int StraightsCount = 4;
		/// <summary>
		///	    1
		///	  -----
		/// 4 |   | 2
		///   -----
		///     3
		/// </summary>
	    public Straight[] Straights { get; }

	    public Rectangle(params Point[] points)
	    {
		    if(points.Length != StraightsCount) throw new ArgumentException(nameof(points));
		    if(!ArePointsValid(points)) throw new ArgumentException(nameof(points));
		    Straights = new Straight[StraightsCount]
		                {
			                new Straight(points[0], points[1]),
			                new Straight(points[1], points[2]),
			                new Straight(points[2], points[3]),
			                new Straight(points[3], points[0])
		                };
		    
	    }

	    protected bool ArePointsValid(params Point[] points)
	    {
		    var diagonal1 = Point.Length(points[0], points[2]);
		    var diagonal2 = Point.Length(points[1], points[3]);
		    return diagonal1 == diagonal2;
	    }

	    public Rectangle(params Straight[] straights)
	    {
		    if (straights.Length != StraightsCount) throw new ArgumentException(nameof(straights));
			if (!ArePointsValid(straights[0].First, straights[0].Second,
			                    straights[1].First, straights[1].Second,
			                    straights[2].First, straights[2].Second,
			                    straights[3].First, straights[3].Second)) throw new ArgumentException(nameof(straights));
			Straights = straights;
	    }

	    public IEnumerable<(Point, Point)> GetSideParallelIntersectionPoints(IEnumerable<Straight> straights)
	    {
		    var lines = straights.ToArray();
		    foreach(var line in lines)
			    if (line.IsIntersectWith(Straights[3]) && line.IsIntersectWith(Straights[1]))
					yield return (Straights[3].IntersectionWith(line), Straights[1].IntersectionWith(line));
	    }

	    public double Square() => Straights[0].Length * Straights[1].Length;
    }
}
