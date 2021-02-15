#region Using derectives

using RSPO_UP_15.Exceptions;
using RSPO_UP_15.Interfaces;

#endregion

namespace RSPO_UP_15.Entities
{
    public abstract class Person : ISayable, IPerson
    {
        protected Person(string firstName, string secondName, string mobileNumber)
        {
            if (firstName == null ||
                secondName == null ||
                mobileNumber == null) throw new BadPersonProfile();

            FirstName = firstName;
            SecondName = secondName;
            MobileNumber = mobileNumber;
        }

        public string MobileNumber { get; }
        public string FirstName { get; }

        public string SecondName { get; }

        public virtual string Say() => "I'm a Person!";
    }
}