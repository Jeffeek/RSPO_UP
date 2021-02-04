using System;
using System.Linq;
using System.Threading.Tasks;

namespace RSPO_UP_16
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await FirstTask();
        }

        private static async Task FirstTask()
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
            {
                Console.Write("Введи число: ");
                if (long.TryParse(Console.ReadLine(), out var num))
                {
                    FactorialMinDigit(num);
                }
            }
        }

        private static async Task FactorialMinDigit(long number)
        {
            var min = await MinDigit(number);
            var result = 1;
            //await Task.Delay(1000);
            await Task.Run(() => 
                           {
                               for (var i = 1; i <= min; i++)
                                   result *= i;
                           });
            
            Console.WriteLine($"Факториал минимальной цифры {number}: {result}");
        }

        private static async Task<int> MinDigit(long number)
        {
            return await Task.Run(() =>
                           {
                               number = Math.Abs(number);
                               return number.ToString().Select(x => int.Parse(x.ToString())).Min();
                           });
        }
    }
}
