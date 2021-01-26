namespace RSPO_UP_6.Model.Map
{
	public interface IMap
	{
		bool[,] Map { get; }
		int Size { get; }
		bool IsCellFree(int row, int column);
	}
}