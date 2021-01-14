using System;
using System.Linq;
using RSPO.dotNet;

namespace RSPO_UP_7.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("Первое задание: ");
            var formule = new AlphaFormule(-15.246, 4.642e-2, 20.001e2);
            System.Console.WriteLine(formule.Calculate());
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Второе задание: ");
            System.Console.WriteLine("Введите A: ");
            double A = double.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Введите N: ");
            int N = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine($"Результат: {PowMath.Pow(A, N)}");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Третье задание: ");
            System.Console.WriteLine("Введите N: ");
            N = int.Parse(System.Console.ReadLine());
            while (N <= 0)
                N = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine(LargestIntegerKSquareNotExceedN.Calculate((uint)N));
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Четвертое задание: ");
            var prime = new PrimeNumbers(Enumerable.Range(1000, 8999));
            var primeResult = prime.FirstSecondEqualsThirdFourth();
            var res = String.Join(Environment.NewLine, primeResult);
            System.Console.WriteLine(res);
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Пятое задание: ");
            System.Console.WriteLine("Введите N (до какого числа): ");
            N = int.Parse(System.Console.ReadLine());
            while (N <= 0)
                N = int.Parse(System.Console.ReadLine());
            var list = Enumerable.Range(0, N).ToList();
            var perm = list.GetPermutations(list.Count).Select(x => String.Concat(x));
            System.Console.WriteLine(String.Join(Environment.NewLine, perm));
        }
    }
}
