#region Using namespaces

using System.Data.Entity;
using RSPO_UP_3.Models.EntityFramework.Models;

#endregion

namespace RSPO_UP_3.Models.EntityFramework
{
	internal class QuizDbContext : DbContext
	{
		public QuizDbContext() : base("QuizDBConnection") { }

		public DbSet<User> Users { get; set; }
		public DbSet<Entrance> Entrances { get; set; }
	}
}