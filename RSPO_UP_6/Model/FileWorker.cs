using System;
using System.IO;

namespace RSPO_UP_6.Model
{
    public class FileWorker
    {
        public event EventHandler PathChanged;
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

        public FileWorker(string path)
        {
            Path = path;
        }

        public string Read()
        {
            string text;
            using (var reader = new StreamReader(Path))
                text = reader.ReadToEnd();
            return text;
        }
    }
}
