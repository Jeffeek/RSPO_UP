#region Using namespaces

using System;
using System.IO;
using RSPO_UP_10.Library;

#endregion

namespace RSPO_UP_10.Cnsle
{
	internal static class Program
	{
		// ReSharper disable once UnusedParameter.Local
		private static void Main(string[] args)
		{
			SquareOfSub();
			CubeOfSecondDigit();
			ComplexNumbers();
			MatrixCompareByPrime();
			StringConcat();
			IsPointInFigure();
		}

		// Реализовать функцию возведения в квадрат разности двух целых чисел 
		private static void SquareOfSub()
		{
			int a = 5, b = 12;
			var first = new First(a, b);
			var answer = first.SquareOfSub();
			if (answer != 49) throw new Exception();

			first = new First($"{Directory.GetCurrentDirectory()}\\first.txt");
			answer = first.SquareOfSub();
			if (answer != 9) throw new Exception();
		}

		// Реализовать функцию возведения в куб второй цифры числа 
		private static void CubeOfSecondDigit()
		{
			var number = 130;
			var second = new Second(number);
			var cube = second.CubePowSecondDigit();
			if (cube != 27) throw new Exception();
		}

		// Создать класс комплексное число с полями: действительная и мнимая части вещественного типа
		// и методами: создание объекта, вывод объекта. Реализовать перегрузку операции умножения
		// для комплексных чисел и перегрузку метода создания объекта для двух
		// параметров(два вещественных числа — для инициализации поля, без параметра —
		// инициализация поля случайным значением в пределах от 1 до 20).
		private static void ComplexNumbers()
		{
			var first = new ComplexNumber(3, 5);
			Console.WriteLine(first);
			var second = new ComplexNumber(10, 3);
			Console.WriteLine(second);
			var mul = first * second;
			Console.WriteLine(mul);
		}

		//Создать класс матрица с полем: матрица и методами: создание объекта, вывод объекта.
		//Реализовать перегрузку операции сравнения (<=,>=) двух матриц в соответствии
		//с вариантом и перегрузку метода создания объекта для двух параметров
		//(два целых числа— инициализация размерности, элементы матрицы случайны в пределах
		//от 1 до 15, строковая переменная – имя файла, из которого происходит чтение матрицы).

		//Большей считается та матрица, у которой сумма простых элементов на главной диагонали больше
		private static void MatrixCompareByPrime()
		{
			var biggerMatrix = new Matrix($"{Directory.GetCurrentDirectory()}\\biggerMatrix.txt");
			var initMatrix = new Matrix($"{Directory.GetCurrentDirectory()}\\initMatrix.txt");
			var result = biggerMatrix >= initMatrix;
			if (result != true) throw new Exception();
		}

		//В результате конкатенации двух строк получается строка в которой идет все символы,
		//стоящие на четных местах в первой строке, затем все символы, стоящие на четных во второй,
		//затем на нечетных в первой и во второй. Пример С1=’ABCD’, C2=’EFGHJK’, C1+C2=’BDFHKACEGJ’
		private static void StringConcat()
		{
			var first = "ABCD";
			var second = "EFGHJK";
			var result = first.StrangeConcat(second);
			if ("BDFHKACEGJ" != result) throw new Exception();
		}

		// Проверка попадает ли заданная точка в фигуру(3 вариант)
		private static void IsPointInFigure()
		{
			var radius = 5;
			var pointX = -7;
			var pointY = -3;

			var figure = new StrangeFigure(radius);
			var point = new Point(pointX, pointY);
			var result = figure | point;

			Console.Write($"Figure: radius = {radius} -> ");
			Console.Write($"Point: x: {pointX}, y: {pointY} => ");
			Console.Write(result);
		}
	}
}