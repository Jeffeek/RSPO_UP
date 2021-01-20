using System;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
    public class Triangle : AngleFigure
    {
        private const int StraightCount = 3;
        public double Height1 { get; }
        public double Height2 { get; }
        public double Height3 { get; }

        public Triangle(params Straight[] straights) : base(straights)
        {
	        Square = Math.Sqrt(HalfPerimeter *
	                           (HalfPerimeter - Straights[2].Length) *
	                           (HalfPerimeter - Straights[0].Length) *
	                           (HalfPerimeter - Straights[1].Length));
	        
	        Height1 = 2 * Square / Straights[2].Length;
	        Height2 = 2 * Square / Straights[0].Length;
	        Height3 = 2 * Square / Straights[1].Length;
        }

        #region Overrides of FigureBase

        /// <inheritdoc />
        public override bool ArePointsValid(params Point[] points)
        {
	        if(points.Length != StraightCount * 2) throw new ArgumentException(nameof(points));
	        //TODO: доделать проверку
	        return true;
        }

        #endregion
    }
}
