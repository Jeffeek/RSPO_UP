#region Using namespaces

using System;
using System.IO;

#endregion

namespace RSPO_UP_6.Model
{
	public class FileWorker
	{
		private string _path;

		public FileWorker(string path) => Path = path;

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

		public string Read()
		{
			string text;
			using (var reader = new StreamReader(Path))
				text = reader.ReadToEnd();

			return text;
		}
	}
}