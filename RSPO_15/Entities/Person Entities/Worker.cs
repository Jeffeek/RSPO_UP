#region Using derectives

using System.Text;
using RSPO_UP_15.Interfaces;

#endregion

namespace RSPO_UP_15.Entities
{
    public abstract class Worker : Employee, IWorker, ISkills
    {
        /// <inheritdoc />
        protected Worker(string firstName, string secondName, string mobileNumber) : base(firstName, secondName,
                                                                                          mobileNumber) { }

        #region Implementation of ISkills

        /// <inheritdoc />
        public string[] Skills { get; set; }

        #endregion

        #region Overrides of Person

        /// <inheritdoc />
        public override string Say() => "I'm a Worker";

        #endregion

        public virtual string GoWorking() => "Worker works!";

        #region Overrides of Employee

        /// <inheritdoc />
        public override string GoHire() => "I'm working now! I don't need a new job";

        #endregion

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(FirstName);
            sb.Append($" {SecondName}");
            sb.AppendLine(MobileNumber);
            sb.AppendLine("Skills: ");
            foreach (var skill in Skills) sb.AppendLine(skill);

            return sb.ToString();
        }

        #endregion
    }
}