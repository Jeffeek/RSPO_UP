namespace RSPO_UP_10.Library
{
	public sealed class StrangeFigure
	{
		public StrangeFigure(int radius) => Radius = radius;

		public int Radius { get; }
		public Point CenterPoint { get; } = new Point(0, 0);

		public static bool operator |(StrangeFigure figure, Point point)
		{
			if (point.Y >= 0 &&
			    point.X * point.X + point.Y * point.Y <= figure.Radius * figure.Radius) return true;

			return ((point.X - figure.CenterPoint.X) * (-figure.Radius - figure.CenterPoint.Y) -
			        (point.Y - figure.CenterPoint.Y) * (figure.CenterPoint.X - figure.CenterPoint.Y)) *
			       ((-figure.Radius - figure.CenterPoint.X) * (-figure.Radius - figure.CenterPoint.Y) -
			        (-figure.Radius - figure.CenterPoint.X) * (figure.CenterPoint.X - figure.CenterPoint.Y)) >=
			       0 &&
			       ((point.X - figure.CenterPoint.X) * (-figure.Radius - -figure.Radius) -
			        (point.Y - -figure.Radius) * (-figure.Radius - figure.CenterPoint.X)) *
			       ((figure.CenterPoint.X - figure.CenterPoint.Y) * (-figure.Radius - -figure.Radius) -
			        (figure.CenterPoint.X - -figure.Radius) * (-figure.Radius - figure.CenterPoint.Y)) >=
			       0 &&
			       ((point.X - -figure.Radius) * (figure.CenterPoint.X - -figure.Radius) -
			        (point.Y - -figure.Radius) * (figure.CenterPoint.Y - -figure.Radius)) *
			       ((figure.CenterPoint.X - -figure.Radius) * (figure.CenterPoint.Y - -figure.Radius) -
			        (-figure.Radius - -figure.Radius) * (figure.CenterPoint.Y - -figure.Radius)) >=
			       0;
		}
	}
}