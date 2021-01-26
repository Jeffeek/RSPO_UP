#region Using namespaces

using RSPO_UP_9.Geometry.Fundamental;

#endregion

namespace RSPO_UP_9.Geometry
{
	public class Square : Rectangle
	{
		public Square(params Straight[] straights) : base(straights) { }
	}
}