using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_3.Models.EntityFramework.Models
{
    public class Entrance
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Date { get; set; }
    }
}
