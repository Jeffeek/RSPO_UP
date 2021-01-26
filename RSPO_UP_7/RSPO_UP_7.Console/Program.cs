#region Using namespaces

using System;
using System.Linq;
using RSPO.dotNet;

#endregion

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
			var a = double.Parse(System.Console.ReadLine() ?? string.Empty);
			System.Console.WriteLine("Введите N: ");
			var n = int.Parse(System.Console.ReadLine() ?? string.Empty);
			System.Console.WriteLine($"Результат: {PowMath.Pow(a, n)}");
			System.Console.WriteLine("----------------------");
			System.Console.WriteLine("Третье задание: ");
			System.Console.WriteLine("Введите N: ");
			n = int.Parse(System.Console.ReadLine() ?? string.Empty);
			while (n <= 0)
				n = int.Parse(System.Console.ReadLine() ?? string.Empty);

			System.Console.WriteLine(LargestIntegerKSquareNotExceedN.Calculate((uint) n));
			System.Console.WriteLine("----------------------");
			System.Console.WriteLine("Четвертое задание: ");
			var prime = new PrimeNumbers(Enumerable.Range(1000, 8999));
			var primeResult = prime.FirstSecondEqualsThirdFourth();
			var res = string.Join(Environment.NewLine, primeResult);
			System.Console.WriteLine(res);
			System.Console.WriteLine("----------------------");
			System.Console.WriteLine("Пятое задание: ");
			System.Console.WriteLine("Введите N (до какого числа): ");
			n = int.Parse(System.Console.ReadLine() ?? string.Empty);
			while (n <= 0)
				n = int.Parse(System.Console.ReadLine() ?? string.Empty);

			var list = Enumerable.Range(0, n).ToList();
			var perm = list.GetPermutations(list.Count).Select(x => string.Concat(x));
			System.Console.WriteLine(string.Join(Environment.NewLine, perm));
		}
	}
}