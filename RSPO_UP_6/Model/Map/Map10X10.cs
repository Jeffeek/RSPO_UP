namespace RSPO_UP_6.Model.Map
{
	public class Map10X10 : MapBase
	{
		public Map10X10(bool[,] matrix) : base(matrix) { }
		public override int Size { get; } = 10;
	}
}