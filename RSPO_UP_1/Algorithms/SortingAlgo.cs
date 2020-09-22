using System;
using System.Collections.Generic;
using System.Linq;
using RSPO_UP_1.Locators;
using RSPO_UP_1.Models;
using UP_1.Algorithms;

namespace RSPO_UP_1.Algorithms
{
    public class SortingAlgo : IAlgo
    {
        private List<Movie> _movies;

        public SortingAlgo()
        {
            _movies = new MovieDeserializer().GetMovies();
        }

        public SortingAlgo(List<Movie> list)
        {
            _movies = list;
        }

        public void Start()
        {
            int answer;
            if (int.TryParse(Console.ReadLine(), out answer))
            {
                switch (answer)
                {
                    case 1:
                    {
                        SortByName();
                        break;
                    }

                    case 2:
                    {
                        SortByPrice();
                        break;
                    }

                    case 3:
                    {
                        SortByCinemaName();
                        break;
                    }

                    case 4:
                    {
                        SortByDate();
                        break;
                    }
                }
            }
        }

        private void PrintList(IEnumerable<Movie> list)
        {
            foreach (var sortedItem in list)
            {
                Console.WriteLine(sortedItem);
            }
        }

        public List<Movie> SortByName()
        {
            var sortedItems = _movies.OrderBy(x => x.Name);
            Console.WriteLine("Список, отсортированный по имени: ");
            PrintList(sortedItems);
            return sortedItems.ToList();
        }

        public List<Movie> SortByPrice()
        {
            var sortedItems = _movies.OrderBy(x => x.Price);
            Console.WriteLine("Список, отсортированный по цене: ");
            PrintList(sortedItems);
            return sortedItems.ToList();
        }

        public List<Movie> SortByDate()
        {
            var sortedItems = _movies.OrderBy(x => x.Date);
            Console.WriteLine("Список, отсортированный по дате: ");
            PrintList(sortedItems);
            return sortedItems.ToList();
        }

        public List<Movie> SortByCinemaName()
        {
            var sortedItems = _movies.OrderBy(x => x.CinemaName);
            Console.WriteLine("Список, отсортированный по имени кинотеатра: ");
            PrintList(sortedItems);
            return sortedItems.ToList();
        }
    }
}
