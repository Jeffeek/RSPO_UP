using System;
using System.Diagnostics;

namespace RSPO_UP_2.View
{
    public class MainView
    {
        public MainView()
        {
            StartMessage();
            StartView();
        }

        private void StartMessage()
        {
            Console.WriteLine("База данных магазина обуви");
        }

        private void StartView()
        {
            int answer = -1;
            while (true)
            {
                Console.WriteLine("0. Выход");
                Console.WriteLine("1. Просмотр информации БД");
                Console.WriteLine("2. Поиск записей и сортировка");
                Console.WriteLine("3. Добавление записей");
                Console.WriteLine("4. Удаление информации");

                if (int.TryParse(Console.ReadLine(), out answer))
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
                            var showView = new ShowInfoView();
                            break;
                        }

                        case 2:
                        {
                            var sortView = new SortAndSearchView();
                            break;
                        }

                        case 3:
                        {
                            AddView add = new AddView();
                            break;
                        }

                        case 4:
                        {
                            RemoveView remove = new RemoveView();
                            break;
                        }
                    }
                }
            }
        }
    }
}
