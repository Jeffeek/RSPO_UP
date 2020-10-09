using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_3.Models.EntityFramework.Models
{
    public class User
    {
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}," +
                   $" {nameof(Login)}: {Login}," +
                   $" {nameof(Password)}: {Password}," +
                   $" {nameof(Name)}: {Name}," +
                   $" {nameof(Role)}: {Role}";
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; } = Role.Student;
        public List<Entrance> Entrances { get; set; }
    }
}
