using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
    public class Triangle : IFigure
    {
        private const int StraightCount = 3;
        public Straight[] Straights { get; }

        public Triangle(IEnumerable<Straight> straights)
        {
	        var lines = straights.ToArray();
	        if(lines.Length != StraightCount) throw new ArgumentException(nameof(straights));
	        if (!IsExists(lines)) throw new ArgumentException(nameof(straights));
	        Straights = lines;
        }

        private bool IsExists(Straight[] straights) => straights[1].Length + straights[2].Length - straights[0].Length > 0 &&
                                                       straights[0].Length + straights[2].Length - straights[1].Length > 0 &&
                                                       straights[0].Length + straights[1].Length - straights[2].Length > 0;

        public double Square() => 0.25 *
                                  Math.Sqrt((Straights[0].Length + Straights[1].Length + Straights[2].Length) *
                                            (Straights[1].Length + Straights[2].Length - Straights[0].Length) *
                                            (Straights[0].Length + Straights[2].Length - Straights[1].Length) *
                                            (Straights[0].Length + Straights[1].Length - Straights[2].Length));
    }
}
