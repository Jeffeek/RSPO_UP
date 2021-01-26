#region Using namespaces

using System.Runtime.Serialization;

#endregion

namespace RSPO_UP_5.Model
{
	[DataContract]
	public class User
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Login { get; set; }

		[DataMember]
		public string Password { get; set; }

		[DataMember]
		public UserRole Role { get; set; }
	}

	public enum UserRole
	{
		Teacher,
		Student
	}
}