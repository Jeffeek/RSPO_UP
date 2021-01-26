#region Using namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using RSPO_UP_1.Locators;
using RSPO_UP_1.Models;

#endregion

namespace RSPO_UP_1.Algorithms
{
	public sealed class FilterAlgo : IAlgo
	{
		private readonly List<Movie> _movies;

		public FilterAlgo() => _movies = new MovieDeserializer().GetMovies();

		public FilterAlgo(List<Movie> list) => _movies = list;

		public void Start()
		{
			if (!int.TryParse(Console.ReadLine(), out var answer)) return;
			switch (answer)
			{
				case 1:
				{
					PrintList(_movies);
					break;
				}

				case 2:
				{
					SearchByName();
					break;
				}

				case 3:
				{
					SearchByHighestPrice();
					break;
				}

				case 4:
				{
					SearchByLessTypedPrice();
					break;
				}

				case 5:
				{
					SearchByAfterDate();
					break;
				}

				case 6:
				{
					SearchByHigherThanAveragePrice();
					break;
				}
			}
		}

		private void PrintList(IEnumerable<Movie> list)
		{
			foreach (var item in list) Console.WriteLine(item);
		}

		public List<Movie> SearchByHighestPrice()
		{
			if (_movies.Count > 1)
			{
				var biggestPrice = _movies.Max(x => x.Price);
				var items = _movies.Where(x => x.Price == biggestPrice);
				var enumerable = items as Movie[] ?? items.ToArray();
				if (enumerable.Count() > 1)
				{
					Console.WriteLine("Нашлось несколько сеансов с самой большой ценой: ");
					PrintList(enumerable);
				}
				else
				{
					Console.WriteLine("Сеанс с самой большой ценой: ");
					Console.WriteLine(enumerable.First());
				}

				return enumerable.ToList();
			}

			Console.WriteLine("Сеансов нет");

			return new List<Movie>();
		}

		public List<Movie> SearchByName()
		{
			Console.WriteLine("Введите название фильма: ");
			var searchName = Console.ReadLine();
			var items = _movies.Where(x => x.Name == searchName);
			Console.WriteLine($"Список сеансов с фильмом \"{searchName}\"");
			var enumerable = items as Movie[] ?? items.ToArray();
			PrintList(enumerable);
			return enumerable.ToList();
		}

		public List<Movie> SearchByLessTypedPrice()
		{
			Console.WriteLine("Введите цену: ");
			if (int.TryParse(Console.ReadLine(), out var price))
			{
				var items = _movies.Where(x => x.Price < price);
				var enumerable = items as Movie[] ?? items.ToArray();
				if (!enumerable.Any()) return null;
				Console.WriteLine($"Сеансы с ценой билетов меньше {price}");
				PrintList(enumerable);
				return enumerable.ToList();
			}

			Console.WriteLine("Произошла ошибка ввода!");

			return null;
		}

		public List<Movie> SearchByAfterDate()
		{
			var afterTime = DateTime.Parse("18:00");
			var items = _movies.Where(x => x.Date.Hour > afterTime.Hour);
			Console.WriteLine($"Сеансы, начинающиеся после {afterTime.Hour}");
			var enumerable = items as Movie[] ?? items.ToArray();
			PrintList(enumerable);

			Console.WriteLine($"Количество фильмов: {enumerable.Count()}");
			return enumerable.ToList();
		}

		public List<Movie> SearchByHigherThanAveragePrice()
		{
			if (!_movies.Any())
			{
				Console.WriteLine("Нет сеансов");
				return new List<Movie>();
			}

			var priceSum = _movies.Select(x => x.Price).Sum();
			var averagePrice = (double) priceSum / _movies.Count;
			var higherPriceList = _movies.Where(x => x.Price > averagePrice);
			Console.WriteLine($"Средняя цена: {averagePrice}");
			Console.WriteLine("Сеансы, цена за билет которых выше средней по всем билетам");
			var priceList = higherPriceList as Movie[] ?? higherPriceList.ToArray();
			PrintList(priceList);

			return priceList.ToList();
		}
	}
}