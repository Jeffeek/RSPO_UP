#region Using namespaces

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RSPO_UP_1.Locators;
using RSPO_UP_1.Models;

#endregion

namespace RSPO_UP_1.Algorithms
{
	public class AddDeleteHelper : IAlgo
	{
		private readonly List<Movie> _movies;

		public bool AddNewTicket()
		{
			if (CheckForFileName())
			{
				var movieName = GetMovieName();
				if (CheckForName(movieName))
				{
					var moviePrice = GetMoviePrice();
					var cinemaName = GetMovieCinemaName();
					var movieDate = GeteDateTime();
					var newMovie = new Movie(movieName, moviePrice)
					               {
						               CinemaName = cinemaName,
						               Date = movieDate
					               };

					SerializeTicket(newMovie);
					return true;
				}
			}

			return false;
		}

		public bool SerializeTicket(Movie movie)
		{
			_movies.Add(movie);
			var serializer = new MovieSerializer();
			var result = serializer.WriteMovies(_movies);
			Console.WriteLine(result ? "Объект был записан в файл" : "Объект НЕ был записан");
			return result;
		}

		public bool CanSerializeTicket(List<Movie> list, Movie movie)
		{
			return list.SingleOrDefault(x => x.Name == movie.Name) == null;
		}

		#region Add Getters

		private string GetMovieName()
		{
			Console.WriteLine("Введите имя фильма: ");
			var movieName = Console.ReadLine();
			return !string.IsNullOrWhiteSpace(movieName)
				       ? movieName
				       : throw new Exception(nameof(movieName) + ", ввод некорректен");
		}

		private DateTime GeteDateTime()
		{
			Console.WriteLine("Введите время показа: ");
			if (DateTime.TryParse(Console.ReadLine(), out var movieDate)) return movieDate;
			Console.WriteLine("Ошибка парсинга даты");
			throw new Exception(nameof(movieDate));
		}

		private string GetMovieCinemaName()
		{
			Console.WriteLine("Введите название кинотеатра: ");
			var movieCinema = Console.ReadLine();
			return !string.IsNullOrWhiteSpace(movieCinema)
				       ? movieCinema
				       : throw new Exception(nameof(movieCinema) + ", ввод некорректен");
		}

		private int GetMoviePrice()
		{
			Console.WriteLine("Введите цену билета: ");
			if (int.TryParse(Console.ReadLine(), out var moviePrice)) return Math.Abs(moviePrice);
			Console.WriteLine("Ошибка парсинга цены");
			throw new Exception("проблемы с парсингом цены");
		}

		#endregion

		#region Delete

		public bool DeleteTicket()
		{
			var movieName = GetMovieName();
			if (!CheckForName(movieName))
			{
				DeleteTicketByName(movieName);
				return true;
			}

			return false;
		}

		public void DeleteTicketByName(string deleteName)
		{
			var item = _movies.Find(x => x.Name == deleteName);
			if (item != null)
			{
				_movies.Remove(item);
				var deserializer = new MovieSerializer();
				deserializer.WriteMovies(_movies);
			}
		}

		#endregion

		#region Check's

		public bool CheckForFileName()
		{
			int answer;
			var typedName = string.Empty;
			Console.WriteLine("Хотите ввести имя файла? \n1.Да\n2.Нет");
			if (int.TryParse(Console.ReadLine(), out answer))
			{
				switch (answer)
				{
					case 1:
					{
						Console.WriteLine("Введите имя файла: ");
						typedName = Console.ReadLine();
						break;
					}

					case 2:
					{
						Console.WriteLine("Хорошо!");
						return true;
					}
				}
			}

			if (typedName != FileSettings.Name)
			{
				Console.WriteLine("Введенное имя файла не совпадает с настройками.");
				Console.WriteLine($"Создать ли новый файл с именем: {typedName}?\n1. Да\n2.Нет");
				if (int.TryParse(Console.ReadLine(), out answer))
				{
					switch (answer)
					{
						case 1:
						{
							File.Create(FileSettings.Path);
							FileSettings.Path = typedName;
							Console.WriteLine("Создан новый json файл. Настройка пути была сменена");
							break;
						}

						case 2:
						{
							Console.WriteLine("Хорошо!");
							break;
						}
					}
				}
				else
					Console.WriteLine("Неудачный парсинг");

				return false;
			}

			return true;
		}

		public bool CheckForName(string name)
		{
			return _movies.SingleOrDefault(x => x.Name == name) == null;
		}

		#endregion

		#region Constructor and start

		public AddDeleteHelper() => _movies = new MovieDeserializer().GetMovies();

		public AddDeleteHelper(List<Movie> list) => _movies = list;

		public void Start()
		{
			if (int.TryParse(Console.ReadLine(), out var answer))
			{
				switch (answer)
				{
					case 1:
					{
						AddNewTicket();
						break;
					}

					case 2:
					{
						DeleteTicket();
						break;
					}
				}
			}
			else
				Console.WriteLine(nameof(answer) + " - парсинг не удался");
		}

		#endregion
	}
}