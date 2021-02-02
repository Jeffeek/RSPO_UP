using System;
using System.Runtime.Serialization;

namespace RSPO_UP_14.Third_Task.Models
{
	[DataContract]
	public sealed class Fact
    {
	    [DataMember]
	    public string Text { get; set; }
	    
	    [DataMember]
	    public DateTime Date { get; set; }

	    public static bool operator >(Fact first, Fact second) => first.Date > second.Date;
		public static bool operator <(Fact first, Fact second) => first.Date < second.Date;

		#region Overrides of Object

		/// <inheritdoc />
		public override string ToString() => $"{nameof(Date)}: {Date} | {nameof(Text)}: {Text}";

		#endregion
    }
}
