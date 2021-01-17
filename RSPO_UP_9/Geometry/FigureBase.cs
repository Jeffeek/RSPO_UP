using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSPO_UP_9.Geometry.Fundamental;

namespace RSPO_UP_9.Geometry
{
    public abstract class FigureBase : IFigure
    {
	    #region Implementation of IFigure

	    /// <inheritdoc />
	    public virtual double Perimeter { get; protected set; }

	    /// <inheritdoc />
	    public virtual double HalfPerimeter { get; protected set; }
	    
	    /// <inheritdoc />
	    public virtual double Square { get; protected set; }

	    /// <inheritdoc />
	    public Straight[] Straights { get; }

	    /// <inheritdoc />
	    public abstract bool ArePointsValid(params Straight[] straights);

	    protected FigureBase(params Straight[] straights)
	    {
		    // ReSharper disable once VirtualMemberCallInConstructor
		    if(!ArePointsValid(straights)) throw new ArgumentException(nameof(straights));
		    Straights = straights;
		    Perimeter = Straights.Sum(x => x.Length);
			HalfPerimeter = Perimeter / 2;
	    }

	    #endregion
    }
}
