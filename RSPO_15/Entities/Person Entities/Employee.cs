#region Using derectives

using RSPO_UP_15.Interfaces;

#endregion

namespace RSPO_UP_15.Entities
{
    public abstract class Employee : Person, IEmployee, IWorkable
    {
        /// <inheritdoc />
        protected Employee(string firstName, string secondName, string mobileNumber) : base(firstName, secondName,
                                                                                            mobileNumber) { }

        public virtual string GoHire() => "Employee goes to hire a new job!";

        public int WorkYears { get; set; }

        #region Overrides of Person

        /// <inheritdoc />
        public override string Say() => "I'm an employee!";

        #endregion
    }
}