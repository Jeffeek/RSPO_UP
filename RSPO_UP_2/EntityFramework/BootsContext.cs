using System.Data.Entity;
using RSPO_UP_2.EntityFramework.Models;

namespace RSPO_UP_2.EntityFramework
{
    internal class BootsContext : DbContext
    {
        public BootsContext() : base("BootsDbConnection")
        {
        }

        public DbSet<Boot> Boots { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
