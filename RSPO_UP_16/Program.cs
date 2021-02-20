#region Using derectives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

/*

*   1. Написать три различных метода, которые выполняют различные действия с
    массивом. В качестве параметра передается целое число n и массив (удаление n первых
    элементов, изменение всех элементов путем целочисленного деления на n, поменять
    местами максимальный и nй элемент массива) в каждом методе вывести массив. Вызов
    методов осуществить с помощью многоадресного делегата. Реализовать 2 варианта: вызов
    всех методов подряд и организовать меню для выбора вызываемого метода. (3 балла).
    2. Описать класс, внутри которого реализовать событие, которое возникает при
    выборе пункта меню, описанного выше. Аргументы для обработчика события: массив и
    булевская переменная. В обработчике события, в зависимости от значения булевской
    переменной, true – входной массив, переданный в обработчик события, изменяется:
    каждый элемент заменяется его суммой цифр, либо False – не изменяется, после чего
    вызывается вышеописанный делегат. Булевскую переменную и массив задает
    пользователь, при выборе пункта меню. (2 балла).
    3. Пользователь вводит коллекцию чисел. Создать дополнительный поток, в
    котором будет происходить нахождение суммы четных цифр каждого числа из заданной
    коллекции. (2 балла).
    4. Изменить третье задание таким образом, чтобы элементы коллекции,
    генерировались случайно (10 элементов) и помещались в эту коллекцию с задержкой 0.3
    секунды, а факториалы для каждого элемента считались с задержкой в 0.7 секунд в
    отдельном потоке. (1 балл).
*   Должны быть события по прибытию космического корабля, по отбытию космического
    корабля
    На космическом крейсере оборудовано N причалов, каждый из которых может
    обслуживать любые типы кораблей. Однако одновременно у причальной ангары может
    находиться не более одного корабля.
    Если при захождении корабля на посадку имеются свободные причальные анграры,
    корабль сразу же направляется к свободному причалу с наименьшим номером. В
    противном случае он становится в очередь (количество кораблей равно M). Если рейд
    переполнен генерировать исключения (в выходной файл информацию записывать)
    Если причал освобождается, а на рейде есть ожидающие своей очереди корабли, к
    этому причалу сразу же направляется первый из таких кораблей.
    Смоделируйте работу порта на основании записей о наступающих событиях. Эти
    записи упорядочены в хронологическом порядке, и считается, что одномоментно не
    может наступить более одного события. В начальный момент времени все причалы
    свободны.
    Входные данные расположены в текстовом файле WARSHIPS.IN. Первая строка
    этого файла содержит величину N и M. Далее располагаются строки с информацией о
    наступающих событиях. Каждая такая строка имеет один из следующих форматов:
    1 Santa Maria (корабль Santa Maria прибыл в порт)
    2 6 (причал № 6 освободился)
    3 in(необходимо вывести информацию о текущем состоянии очереди на рейде)
    4 out(необходимо вывести информацию о текущем состоянии причалов,
    включающую названия стоящих у них кораблей) Необходимо выполнить проверку на
    существование и пустоту файла, но после проверки данные считаются верными как по
    формату, так и по сути (так, не будет записей об освобождении уже свободного причала).
    Выходные данные должны помещаться в текстовый файл WARSHIPS.OUT и описывать
    работу порта в формате, удобном для чтения человеком. Если проверка на существование
    и пустоту входного файла завершилась неудачно, соответствующую информацию также
    необходимо записать в выходной файл.
*/
namespace RSPO_UP_16
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //MenuTask();
            //await CalculateSumOfOddDigitsFromCollectionTask();

        }

        private static async Task CalculateSumOfOddDigitsFromCollectionTask()
        {
            int[] GetArrayFromUser()
            {
                int ParseStringToInt()
                {
                    int result;

                    while (!Int32.TryParse(Console.ReadLine(), out result))
                    {
                        Console.WriteLine("Error, try again");
                        Console.WriteLine("Int32 parse: ");
                    }

                    return result;
                }

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

            async Task<int[]> GenerateRandomArray()
            {
                var array = new int[10];
                var rnd = new Random();
                for (var i = 0; i < 10; i++)
                {
                    await Task.Delay(300);
                    array[i] = rnd.Next(0, 30);
                }

                return array;
            }

            async Task WriteFactorialForEach(int[] array)
            {
                for (var i = 0; i < array.Length; i++)
                {
                    await Task.Delay(700);
                    try
                    {
                        var result = 1;
                        for (var j = 1; j < array[i]; j++)
                            result *= i;
                        Console.WriteLine(result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error {e.Message}");
                    }
                }
            }

            int[] collection = null;
            collection = GetArrayFromUser();
            await Task.Run(() => WriteSum(collection));

            collection = await GenerateRandomArray();
            await WriteFactorialForEach(collection);
        }

        private static void WriteSum(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
                Console.WriteLine($"\r\n[{i}]: {array[i].ToString().Select(x => Int32.Parse(x.ToString())).Where(x => x % 2 == 0).Sum()}");
        }

        private static void MenuTask()
        {
            var menu = new ConsoleMenu();
            menu.MenuItemChoosed += Menu_MenuItemChoosed;
            menu.Start();

            void Menu_MenuItemChoosed(int[] array, bool flag)
            {
                Console.WriteLine("EVENT FROM MAIN");
            }
        }
    }
}