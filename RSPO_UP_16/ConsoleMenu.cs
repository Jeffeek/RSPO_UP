using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace RSPO_UP_16
{
    public delegate int[] ArrayWorkerDelegate(int[] array, int N);

    public delegate void ArrayEvent(int[] array, bool flag);

    public class ConsoleMenu
    {
        private readonly ArrayWorkerDelegate _arrayWorker;

        public event ArrayEvent MenuItemChoosed;

        private readonly ArrayWorker _worker = new ArrayWorker();

        public ConsoleMenu()
        {
            _arrayWorker += _worker.RemoveRangeAtStart;
            _arrayWorker += _worker.ChangeByDivOn;
            _arrayWorker += _worker.SwapMaxAndElementAt;
        }

        public void Start()
        {
            var isMenuActive = true;
            while (isMenuActive)
            {
                PrintMenu();
                var menuChoose = GetMenuItem();
                switch (menuChoose)
                {
                    case 1:
                    {
                        var array = GetArrayFromUser();
                        Console.WriteLine("How much elements you want to remove? : ");
                        var elementsToRemoveCount = ParseStringToInt();
                        if (elementsToRemoveCount > array.Length)
                        {
                            Console.WriteLine($"Can't remove {elementsToRemoveCount} elements from array "
                                              + $"where length = {array.Length}");

                            break;
                        }

                        PrintArray(array);
                        MenuItemChoosed?.Invoke(array, true);
                        var newArray = (int[])_arrayWorker
                                              .GetInvocationList()
                                              .ElementAt(0)
                                              .DynamicInvoke(array,
                                                             elementsToRemoveCount);
                        PrintArray(newArray);

                        break;
                    }

                    case 2:
                    {
                        var array = GetArrayFromUser();
                        Console.WriteLine("On what number you want to divide all elements in array? : ");
                        var divideOn = ParseStringToInt();
                        if (divideOn == 0)
                        {
                            Console.WriteLine($"Can't divide on 0");

                            break;
                        }

                        PrintArray(array);
                        MenuItemChoosed?.Invoke(array, true);
                        var newArray = (int[])_arrayWorker
                                              .GetInvocationList()
                                              .ElementAt(1)
                                              .DynamicInvoke(array,
                                                             divideOn);
                        PrintArray(newArray);

                        break;
                    }

                    case 3:
                    {
                        var array = GetArrayFromUser();
                        Console.WriteLine("Write index from array which you want to swap with max element? : ");
                        var indexToSwap = ParseStringToInt();
                        if (indexToSwap < 0 || indexToSwap >= array.Length)
                        {
                            Console.WriteLine($"Can't swap!");

                            break;
                        }

                        PrintArray(array);
                        MenuItemChoosed?.Invoke(array, true);
                        var newArray = (int[])_arrayWorker
                                              .GetInvocationList()
                                              .ElementAt(2)
                                              .DynamicInvoke(array,
                                                             indexToSwap);
                        PrintArray(newArray);

                        break;
                    }

                    case 4:
                    {
                        isMenuActive = false;

                        break;
                    }
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("1. RemoveRangeAtStart");
            Console.WriteLine("2. ChangeByDivOn");
            Console.WriteLine("3. SwapMaxAndElementAt");
            Console.WriteLine("4. Exit");
        }

        private int GetMenuItem()
        {
            Console.WriteLine("Write number from menu: ");
            int answer;
            while (!Int32.TryParse(Console.ReadLine(), out answer) && (answer < 1 || answer > 4))
                Console.WriteLine("Not valid. Try again..");

            return answer;
        }

        private int[] GetArrayFromUser()
        {
            var list = new List<int>();
            Console.WriteLine("Write while you want to add item to array (press enter to cancel)");

            while (true)
            {
                Console.Write($"[{list.Count}]: ");
                var readKey = Console.ReadKey(true);

                if (readKey.Key == ConsoleKey.Enter) break;

                var addItem = ParseStringToInt();
                list.Add(addItem);
            }

            return list.ToArray();
        }

        private int ParseStringToInt()
        {
            int result;

            while (!Int32.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Error, try again");
                Console.WriteLine("Int32 parse: ");
            }

            return result;
        }

        private void PrintArray(int[] array) => Console.WriteLine(String.Join(" ", array));
    }
}