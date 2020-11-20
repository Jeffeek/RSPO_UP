using System;
using System.Collections.Generic;
using System.Linq;
using RSPO_UP_1.Locators;
using RSPO_UP_1.Models;
using UP_1.Algorithms;

namespace RSPO_UP_1.Algorithms
{
    public class FilterAlgo : IAlgo
    {
        private List<Movie> _movies;

        public FilterAlgo()
        {
            _movies = new MovieDeserializer().GetMovies();
        }

        public FilterAlgo(List<Movie> list)
        {
            _movies = list;
        }

        private void PrintList(IEnumerable<Movie> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public List<Movie> SearchByHighestPrice()
        {
            if (_movies.Count > 1)
            {
                int biggestPrice = _movies.Max(x => x.Price);
                var items = _movies.Where(x => x.Price == biggestPrice);
                if (items.Count() > 1)
                {
                    Console.WriteLine("Нашлось несколько сеансов с самой большой ценой: ");
                    PrintList(items);
                }
                else
                {
                    Console.WriteLine("Сеанс с самой большой ценой: ");
                    Console.WriteLine(items.First());
                }

                return items.ToList();
            }
            else
            {
                Console.WriteLine("Сеансов нет");
            }
            return new List<Movie>();
        }

        public List<Movie> SearchByName()
        {
            Console.WriteLine("Введите название фильма: ");
            string searchName = Console.ReadLine();
            var items = _movies.Where(x => x.Name == searchName);
            Console.WriteLine($"Список сеансов с фильмом \"{searchName}\"");
            PrintList(items);
            return items.ToList();
        }

        public List<Movie> SearchByLessTypedPrice()
        {
            Console.WriteLine("Введите цену: ");
            if (int.TryParse(Console.ReadLine(), out int price))
            {
                var items = _movies.Where(x => x.Price < price);
                if (items.Any())
                {
                    Console.WriteLine($"Сеансы с ценой билетов меньше {price}");
                    PrintList(items);
                    return items.ToList();
                }
            }
            else
            {
                Console.WriteLine("Произошла ошибка ввода!");
            }

            return null;
        }

        public List<Movie> SearchByAfterDate()
        {
            DateTime afterTime = DateTime.Parse("18:00");
            var items = _movies.Where(x => x.Date.Hour > afterTime.Hour);
            Console.WriteLine($"Сеансы, начинающиеся после {afterTime.Hour}");
            PrintList(items);

            Console.WriteLine($"Количество фильмов: {items.Count()}");
            return items.ToList();
        }

        public List<Movie> SearchByHigherThanAveragePrice()
        {
            if (!_movies.Any())
            {
                Console.WriteLine("Нет сеансов");
                return new List<Movie>();
            }
            var priceSum = _movies.Select(x => x.Price).Sum();
            double averagePrice = (double)priceSum / _movies.Count;
            var higherPriceList = _movies.Where(x => x.Price > averagePrice);
            Console.WriteLine($"Средняя цена: {averagePrice}");
            Console.WriteLine("Сеансы, цена за билет которых выше средней по всем билетам");
            PrintList(higherPriceList);

            return higherPriceList.ToList();
        }

        public void Start()
        {
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
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
        }
    }
}
