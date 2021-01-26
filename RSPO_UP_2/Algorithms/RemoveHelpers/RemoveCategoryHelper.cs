#region Using namespaces

using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.View;

#endregion

namespace RSPO_UP_2.Algorithms.RemoveHelpers
{
	public class RemoveCategoryHelper
	{
		public RemoveCategoryHelper()
		{
			Remove();
		}

		public bool UpdateDataBase(string categoryName)
		{
			int result;
			using (var db = new BootsContext())
			{
				db.Categories.Load();
				var elem = db.Categories
				             .First(x => x.CategoryName == categoryName);

				db.Categories.Remove(elem);
				result = db.SaveChanges();
			}

			return result == 1;
		}

		private string GetCategoryName()
		{
			Console.WriteLine("Удаляем категорию");
			var bootslist = DbCollectionHelper.GetBoots();
			var categorieslist = DbCollectionHelper.GetCategories();
			ShowInfoView.PrintList(categorieslist);
			Console.WriteLine("Введите название категории: ");
			var name = Console.ReadLine();
			var isUsedCategory = bootslist
			                     .Select(x => x.Category.CategoryName)
			                     .Contains(name);

			var isExists = categorieslist.FirstOrDefault(x => x.CategoryName == name) != null;

			switch (isUsedCategory)
			{
				case false when isExists:
					return name;

				case true:
					Console.WriteLine("Данная категория используется товарами, сначала удалите товары");
					break;
			}

			if (!isExists) Console.WriteLine("Данная категория не найдена");

			throw new Exception();
		}

		private void Remove()
		{
			var categoryName = GetCategoryName();
			UpdateDataBase(categoryName);
		}
	}
}