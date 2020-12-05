using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RSPO_UP_6.Model.Entities
{
    public class Bomb
    {
        public EntitySettings Settings { get; set; }

        public Bomb()
        {
            Settings = new EntitySettings {ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\bomb.png"};
        }
    }
}
