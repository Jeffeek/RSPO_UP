namespace RSPO_UP_6.Model.Map
{
    public class Map10X10 : MapBase
    {
        public override int Size { get; } = 10;

        public Map10X10(bool[,] matrix) : base(matrix) { }
    }
}
