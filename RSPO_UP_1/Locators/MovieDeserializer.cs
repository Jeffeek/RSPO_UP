#region Using namespaces

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using RSPO_UP_1.Models;

#endregion

namespace RSPO_UP_1.Locators
{
	public class MovieDeserializer
	{
		private List<Movie> _movies;

		public List<Movie> GetMovies()
		{
			if (!File.Exists(FileSettings.Path))
			{
				//TODO: вывести предупреждение
				File.Create(FileSettings.Path);
				return new List<Movie>();
			}

			try
			{
				using (var fs = new FileStream(FileSettings.Path, FileMode.OpenOrCreate))
				{
					var serializer = new DataContractJsonSerializer(typeof(List<Movie>));
					_movies = serializer.ReadObject(fs) as List<Movie>;
				}

				return _movies ?? throw new ArgumentNullException($"{_movies} NULL");
			}
			catch(Exception e)
			{
				Console.WriteLine("MovieSerializer error");
				Console.WriteLine(e.Message);
			}

			return new List<Movie>();
		}
	}
}