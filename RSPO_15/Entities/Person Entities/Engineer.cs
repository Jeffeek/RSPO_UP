#region Using derectives

using RSPO_UP_15.Interfaces;

#endregion

namespace RSPO_UP_15.Entities
{
    public class Engineer : Worker, IProfessional, IEngineer
    {
        /// <inheritdoc />
        public Engineer(string firstName, string secondName, string mobileNumber) : base(firstName, secondName,
                                                                                         mobileNumber) { }

        #region Implementation of IEngineer

        /// <inheritdoc />
        public string GoDoEngineer() => "Going to do engineer things! WOW!";

        #endregion

        #region Implementation of IProfessional

        /// <inheritdoc />
        public string GoDoProfessionalThings() => GoDoEngineer();

        #endregion

        #region Overrides of Employee

        /// <inheritdoc />
        public override string GoHire() => base.GoHire() + " as Engineer";

        #endregion

        #region Overrides of Person

        /// <inheritdoc />
        public override string Say() => "I'm an engineer";

        #endregion

        #region Overrides of Worker

        /// <inheritdoc />
        public override string GoWorking() => base.GoWorking() + " as Engineer";

        #endregion
    }
}