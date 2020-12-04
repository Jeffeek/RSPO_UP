using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_6.Model
{
    public class FileWorker
    {
        private string _path;
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                PathChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler PathChanged;

        public FileWorker(string path)
        {
            Path = path;
        }

        public string Read()
        {
            var sb = new StringBuilder();
            using (var reader = new StreamReader(Path))
            {
                sb.Append(reader.ReadLine());
            }

            return sb.ToString();
        }
    }
}
