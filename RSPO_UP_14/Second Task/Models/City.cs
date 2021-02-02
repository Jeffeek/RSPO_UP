using System.Runtime.Serialization;

namespace RSPO_UP_14.Second_Task.Models
{
	[DataContract]
    public sealed class City
    {
	    [DataMember]
	    public string Name { get; set; }
	    
	    [DataMember]
	    public long Population { get; set; }
    }
}
