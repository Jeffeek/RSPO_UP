using System.IO;

namespace RSPO_UP_6.Model.Entities
{
    public class Cow
    {
        public int Lives { get; set; } = 3;
        public EntitySettings Settings { get; set; }

        public Cow()
        {
            Settings = new EntitySettings()
            {
                Delay = 0,
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\cow.gif"
            };
        }
    }
}
