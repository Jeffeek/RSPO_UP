#region Using namespaces

using System;
using System.IO;
using RSPO_UP_1.Algorithms;

#endregion

namespace RSPO_UP_1.Locators
{
	public static class FileSettings
	{
		private static string _path = $"{Directory.GetCurrentDirectory()}\\MoviesList.json";

		public static string Name { get; private set; } = "MoviesList";

		public static string Path
		{
			get => _path;
			set
			{
				if (!string.IsNullOrEmpty(value) &&
				    !string.IsNullOrWhiteSpace(value) &&
				    new FileNameAlgo().IsRightName(value))
				{
					_path = $"{Directory.GetCurrentDirectory()}\\{value}.json";
					Name = value;
				}
				else
					throw new ArgumentException(nameof(Path) + " - строка имела неверный формат");
			}
		}
	}
}