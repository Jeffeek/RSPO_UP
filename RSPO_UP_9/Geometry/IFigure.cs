using System;
using System.Collections.Generic;
using System.Text;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
    interface IFigure
    {
        double Square { get; }
        double Perimeter { get; }
        double HalfPerimeter { get; }
        public Straight[] Straights { get; }
        bool ArePointsValid(params Straight[] straights);
    }
}
