using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RSPO_UP_6.Model.Entities
{
    public class Wolf
    {
        public EntitySettings Settings { get; set; }

        public Wolf()
        {
            Settings = new EntitySettings()
            {
                Delay = 200,
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\wolf.png"
            };
        }
    }
}
