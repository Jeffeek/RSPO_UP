using static System.Console;

namespace RSPO_UP_14.Fourth_Task
{
    public class Implementation : IInterface
    {
	    public Implementation(string firstName, string secondName)
	    {
		    FirstName = firstName;
		    SecondName = secondName;
	    }

	    #region Implementation of IInterface

	    /// <inheritdoc />
	    public string FirstName { get; }

	    /// <inheritdoc />
	    public string SecondName { get; }

	    /// <inheritdoc />
	    public void Print() => WriteLine("Implementation!");

	    #endregion
    }
}
