#region Using namespaces

using System.Collections.Generic;

#endregion

namespace RSPO_UP_3.Models.EntityFramework.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public Role Role { get; set; } = Role.Student;
		public List<Entrance> Entrances { get; set; }

		public override string ToString() => $"{nameof(Id)}: {Id}," +
		                                     $" {nameof(Login)}: {Login}," +
		                                     $" {nameof(Password)}: {Password}," +
		                                     $" {nameof(Name)}: {Name}," +
		                                     $" {nameof(Role)}: {Role}";
	}
}