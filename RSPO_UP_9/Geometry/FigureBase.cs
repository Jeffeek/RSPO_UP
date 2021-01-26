#region Using namespaces

using System;
using System.Diagnostics.CodeAnalysis;
using RSPO_UP_9.Geometry.Fundamental;

#endregion

namespace RSPO_UP_9.Geometry
{
	[SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
	public abstract class FigureBase : IFigure
	{
		#region Implementation of IFigure

		/// <inheritdoc />
		public double Perimeter { get; protected set; }

		/// <inheritdoc />
		public double HalfPerimeter { get; protected set; }

		/// <inheritdoc />
		public double Square { get; protected set; }

		/// <inheritdoc />
		public abstract bool ArePointsValid(params Point[] points);

		protected FigureBase(params Point[] points)
		{
			if (!ArePointsValid(points)) throw new ArgumentException(nameof(points));
		}

		#endregion
	}
}