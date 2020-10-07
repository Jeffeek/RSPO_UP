using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_3.Annotations;
using RSPO_UP_3.Models.EntityFramework;
using RSPO_UP_3.Models.EntityFramework.Models;

namespace RSPO_UP_3.Services
{
    public static class UsersProvider
    {
        public static List<User> GetUsersList()
        {
            List<User> users;
            using (var con = new QuizDbContext())
            {
                con.Users.Load();
                users = con.Users.ToList();
            }

            return users;
        }

        public static List<Entrance> GetEntrancesList()
        {
            List<Entrance> entrances;
            using (var con = new QuizDbContext())
            {
                con.Users.Load();
                con.Entrances.Load();
                entrances = con.Entrances.ToList();
            }

            return entrances;
        }
    }
}
