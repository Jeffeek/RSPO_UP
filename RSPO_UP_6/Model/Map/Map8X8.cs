namespace RSPO_UP_6.Model.Map
{
    public class Map8X8 : MapBase
    {
        public override int Size { get; } = 8;

        public Map8X8(bool[,] matrix) : base(matrix) { }
    }
}
