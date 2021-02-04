using RSPO_UP_15.Interfaces;

namespace RSPO_UP_15.Entities
{
    public abstract class Worker : Employee, IWorker, ISkills
    {
	    
	    
	    #region Overrides of Person

	    /// <inheritdoc />
	    public override string Say() => "I'm a Worker";

	    #endregion

	    public virtual string GoWorking() => "Worker works!";

	    #region Overrides of Employee

	    /// <inheritdoc />
	    public override string GoHire() => "I'm working now! I don't need a new job";

	    #endregion

	    /// <inheritdoc />
	    protected Worker(string firstName, string secondName, string mobileNumber) : base(firstName, secondName, mobileNumber) { }

	    #region Implementation of ISkills

	    /// <inheritdoc />
	    public string[] Skills { get; }

	    #endregion
    }
}
