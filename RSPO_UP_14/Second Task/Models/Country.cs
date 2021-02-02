using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RSPO_UP_14.Second_Task.Models
{
    [DataContract]
    public sealed class Country
    {
	    [DataMember]
	    public string Name { get; set; }

	    [DataMember]
        public long Population { get; set; }
        
        [DataMember]
        public IEnumerable<City> Cities { get; set; }
    }
}
