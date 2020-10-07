using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_3.Models.EntityFramework.Models;

namespace RSPO_UP_3.Models.EntityFramework
{
    class QuizDbContext : DbContext
    {
        public QuizDbContext() : base("QuizDBConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
    }
}
