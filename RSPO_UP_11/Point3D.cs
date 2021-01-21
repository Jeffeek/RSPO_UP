namespace RSPO_UP_11
{
    public readonly struct Point3D
    {
	    public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point3D(double x, double y, double z)
        {
	        X = x;
            Y = y;
            Z = z;
        }

        #region Overrides of ValueType

        /// <inheritdoc />
        public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Z)}: {Z}";

        #endregion
    }
}
