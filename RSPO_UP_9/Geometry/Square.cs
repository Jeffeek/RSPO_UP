using System;
using System.Collections.Generic;
using System.Text;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
    public class Square : Rectangle
    {
	    public Square(params Point[] points) : base(points) { }

	    public Square(params Straight[] straights) : base(straights) { }

    }
}
