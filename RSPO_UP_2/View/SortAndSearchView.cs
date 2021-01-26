#region Using namespaces

using System;
using System.Diagnostics;
using System.Linq;
using RSPO_UP_2.Algorithms.SortingCollection;

#endregion

namespace RSPO_UP_2.View
{
	public class SortAndSearchView
	{
		public SortAndSearchView()
		{
			SelectModel();
		}

		private void SelectModel()
		{
			Console.WriteLine("1. Сортировка обуви");
			Console.WriteLine("2. Сортировка категорий");
			Console.WriteLine("3. Сортировка продаж");
			if (int.TryParse(Console.ReadLine(), out var answer))
			{
				switch (answer)
				{
					case 1:
					{
						BootSorting();
						break;
					}

					case 2:
					{
						CategorySorting();
						break;
					}

					case 3:
					{
						SaleSorting();
						break;
					}
				}
			}
		}

		private void BootSorting()
		{
			var sortBoots = new SortingCollectionBoots();
			Console.WriteLine("1. Сортировка по цене");
			Console.WriteLine("2. Сортировка по количеству");
			Console.WriteLine("3. Сортировка по названию категории");
			Console.WriteLine("4. Сортировка по названию");
			Console.WriteLine("5. Сортировка по цене(ввод с клавиатуры диапазона)");
			Console.WriteLine("6. Сортировка по названию(ввод с клавиатуры)");
			if (int.TryParse(Console.ReadLine(), out var answer))
			{
				switch (answer)
				{
					case 1:
					{
						sortBoots.SortByPrice();
						break;
					}

					case 2:
					{
						sortBoots.SortByCount();
						break;
					}

					case 3:
					{
						sortBoots.SortByCategoryName();
						break;
					}

					case 4:
					{
						sortBoots.SortByName();
						break;
					}

					case 5:
					{
						Console.WriteLine("Введите диапазон в формате: x-y");
						var range = Console.ReadLine();
						var ints = range?.Split('-').Select(int.Parse).ToArray();
						Debug.Assert(ints != null, nameof(ints) + " != null");
						sortBoots.SortByTypedPrice(ints[0], ints[1]);
						break;
					}

					case 6:
					{
						Console.WriteLine("Введите название товара");
						var name = Console.ReadLine();
						sortBoots.SortByTypedName(name);
						break;
					}
				}
			}
		}

		private void CategorySorting()
		{
			var sortCategory = new SortingCollectionCategory();
			Console.WriteLine("1. Сортировка по названию");
			Console.WriteLine("2. Сортировка по гарантийному сроку");
			Console.WriteLine("3. Найти категорию по названию");
			if (int.TryParse(Console.ReadLine(), out var answer))
			{
				switch (answer)
				{
					case 1:
					{
						sortCategory.SortByCategoryName();
						break;
					}

					case 2:
					{
						sortCategory.SortByGuaranteePeriod();
						break;
					}

					case 3:
					{
						var name = Console.ReadLine();
						sortCategory.SortByTypedCategoryName(name);
						break;
					}
				}
			}
		}

		private void SaleSorting()
		{
			var sortSale = new SortingCollectionSale();
			Console.WriteLine("1. Сортировка по дате");
			Console.WriteLine("2. Сортировка по скидке");
			Console.WriteLine("3. Сортировка по количеству товара");
			Console.WriteLine("4. Сортировка по скидке(ввод с клавиатуры, формат: x-y");
			Console.WriteLine("5. Сортировка по скидке(ввод с клавиатуры");
			if (int.TryParse(Console.ReadLine(), out var answer))
			{
				switch (answer)
				{
					case 1:
					{
						sortSale.SortByDate();
						break;
					}

					case 2:
					{
						sortSale.SortByDiscount();
						break;
					}

					case 3:
					{
						sortSale.SortByCount();
						break;
					}

					case 4:
					{
						Console.WriteLine("Введите скидку в формате: x-y");
						var range = Console.ReadLine();
						if (range != null)
						{
							var numbers = range.Split('-').Select(int.Parse).ToArray();
							sortSale.SortByTypedRangeDiscount(numbers[0], numbers[1]);
						}

						break;
					}

					case 5:
					{
						Console.WriteLine("Введите скидку в формате");
						var discount = int.Parse(Console.ReadLine() ?? string.Empty);
						sortSale.SortByTypedDiscount(discount);
						break;
					}
				}
			}
		}
	}
}