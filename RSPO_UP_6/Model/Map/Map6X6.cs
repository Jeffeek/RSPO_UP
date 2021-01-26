namespace RSPO_UP_6.Model.Map
{
	public class Map6X6 : MapBase
	{
		public Map6X6(bool[,] matrix) : base(matrix) { }
		public override int Size { get; } = 6;
	}
}