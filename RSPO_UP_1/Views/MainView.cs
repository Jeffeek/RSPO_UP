using System;
using System.Diagnostics;
using RSPO_UP_1.Algorithms;
using UP_1.Algorithms;

namespace RSPO_UP_1.Views
{
    public class MainView
    {
        public MainView()
        {
            HelloMessage();
            MainMenu();
        }

        private void HelloMessage()
        {
            Console.WriteLine("Вас приветсвует приложение по поиску билетов в кинотеатры!");
        }

        private void StartAlgorithm(IAlgo algorithm)
        {
            algorithm?.Start();
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("0. Выход");
                Console.WriteLine("1. Работа с файлом");
                Console.WriteLine("2. Просмотр содержимого файла");
                Console.WriteLine("3. Сортировка информации");
                Console.WriteLine("4. Удаление/добавление информации в файла");

                if (int.TryParse(Console.ReadLine(), out int answer))
                {
                    switch (answer)
                    {
                        case 0:
                        {
                            Process.GetCurrentProcess().CloseMainWindow();
                            break;
                        }

                        case 1:
                        {
                            Console.WriteLine("0. Выход");
                            Console.WriteLine("1. Написать имя файла или выбрать существующий");
                            StartAlgorithm(new FileNameAlgo());
                            break;
                        }

                        case 2:
                        {
                            Console.WriteLine("1. Вывести весь список");
                            Console.WriteLine("2. Вывести информацию о фильмах с выбранным названием");
                            Console.WriteLine("3. Вывести название фильма с максимальной ценой");
                            Console.WriteLine("4. Вывести информацию о фильмах с ценой менее заданной");
                            Console.WriteLine("5. Посчитать и вывести общее количество фильмов после 18.00");
                            Console.WriteLine("6. Посчитать и вывести количество фильмов с ценой выше среднего");
                            StartAlgorithm(new FilterAlgo());
                            break;
                        }

                        case 3:
                        {
                            Console.WriteLine("1. Сортировка по имени фильма");
                            Console.WriteLine("2. Сортировка по цене");
                            Console.WriteLine("3. Сортировка по названию кинотеатра");
                            Console.WriteLine("4. Сортировка по дате");
                            StartAlgorithm(new SortingAlgo());
                            break;
                        }

                        case 4:
                        {
                            Console.WriteLine("1. Добавить новый билет");
                            Console.WriteLine("2. Удалить билет");
                            StartAlgorithm(new AddDeleteHelper());
                            break;
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
