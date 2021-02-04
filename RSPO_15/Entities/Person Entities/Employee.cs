using RSPO_UP_15.Interfaces;

namespace RSPO_UP_15.Entities
{
    public abstract class Employee : Person, IEmployee, IWorkable
    {
	    public int WorkYears { get; }
	    
	    #region Overrides of Person

	    /// <inheritdoc />
	    public override string Say() => "I'm an employee!";

	    #endregion

	    public virtual string GoHire() => "Employee goes to hire a new job!";

	    /// <inheritdoc />
	    protected Employee(string firstName, string secondName, string mobileNumber) : base(firstName, secondName, mobileNumber) { }
    }
}
