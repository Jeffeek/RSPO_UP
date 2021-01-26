#region Using namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using RSPO_UP_2.Algorithms;

#endregion

namespace RSPO_UP_2.View
{
	public class ShowInfoView
	{
		public ShowInfoView()
		{
			SelectView();
		}

		private void SelectView()
		{
			Console.WriteLine("0. Выход");
			Console.WriteLine("1. Вывод всей информации что есть");
			Console.WriteLine("2. Вывод информации о товаре");
			Console.WriteLine("3. Вывод информации о категориях");
			Console.WriteLine("4. Вывод информации о продажах");
			if (!int.TryParse(Console.ReadLine(), out var answer)) return;
			switch (answer)
			{
				case 0:
				{
					break;
				}

				case 1:
				{
					ShowAll();
					break;
				}

				case 2:
				{
					ShowBoots();
					break;
				}

				case 3:
				{
					ShowCategories();
					break;
				}

				case 4:
				{
					ShowSales();
					break;
				}
			}
		}

		private void ShowAll()
		{
			var boots = DbCollectionHelper.GetBoots();
			var categories = DbCollectionHelper.GetCategories();
			var sales = DbCollectionHelper.GetSales();

			Console.WriteLine("\nТовар: \n");
			foreach (var boot in boots)
				Console.WriteLine(boot);

			Console.WriteLine("\nКатегории: \n");
			foreach (var category in categories)
				Console.WriteLine(category);

			Console.WriteLine("\nПродажи: \n");
			foreach (var sale in sales)
				Console.WriteLine(sale);
		}

		private void ShowBoots()
		{
			var boots = DbCollectionHelper.GetBoots();
			Console.WriteLine("\nТовар: \n");
			foreach (var boot in boots)
				Console.WriteLine(boot);
		}

		private void ShowCategories()
		{
			var categories = DbCollectionHelper.GetCategories();
			Console.WriteLine("\nКатегории: \n");
			foreach (var category in categories)
				Console.WriteLine(category);
		}

		private void ShowSales()
		{
			var sales = DbCollectionHelper.GetSales();
			Console.WriteLine("\nКатегории: \n");
			foreach (var sale in sales)
				Console.WriteLine(sale);
		}

		public static void PrintList<T>(IEnumerable<T> list)
		{
			list.ToList().ForEach(x => Console.WriteLine(x));
		}
	}
}