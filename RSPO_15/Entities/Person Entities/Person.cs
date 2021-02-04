using RSPO_UP_15.Exceptions;
using RSPO_UP_15.Interfaces;

namespace RSPO_UP_15.Entities
{
    public abstract class Person : ISayable, IPerson
    {
	    public string FirstName { get; }
	    
	    public string SecondName { get; }
	    
	    public string MobileNumber { get; }
	    
	    protected Person(string firstName, string secondName, string mobileNumber)
	    {
		    if (firstName == null ||
		        secondName == null ||
		        mobileNumber == null) throw new BadPersonProfile();
		    FirstName = firstName;
		    SecondName = secondName;
		    MobileNumber = mobileNumber;
	    }

	    public virtual string Say() => "I'm a Person!";
    }
}
