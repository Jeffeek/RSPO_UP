#region Using namespaces

using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.EntityFramework.Models;

#endregion

namespace RSPO_UP_2.Algorithms.AddHelpers
{
	public class AddCategoryHelper
	{
		public AddCategoryHelper()
		{
			TakeData();
		}

		private bool UpdateDataBase(Category newCategory)
		{
			int result;
			try
			{
				using (var db = new BootsContext())
				{
					db.Categories.Load();
					db.Categories.Add(newCategory);
					result = db.SaveChanges();
				}
			}
			catch
			{
				Console.WriteLine("Не удалось добавить :(");
				return false;
			}

			return result == 1;
		}

		private void TakeData()
		{
			var name = GetName();
			var rules = GetCategoryCareRules();
			var guarantee = GetGuaranteePeriod();
			var category = new Category
			               {
				               CareRules = rules,
				               CategoryName = name,
				               GuaranteePeriod = guarantee
			               };

			if (UpdateDataBase(category))
				Console.WriteLine("Добавление произошло удачно!");
			else
				Console.WriteLine("Добавление произошло НЕ удачно!");
		}

		private string GetName()
		{
			var list = DbCollectionHelper.GetCategories();
			Console.WriteLine("Введите название новой категории: ");
			var name = Console.ReadLine();
			if (!list.Select(x => x.CategoryName).Contains(name)) return name;
			throw new Exception(nameof(name));
		}

		private int GetGuaranteePeriod()
		{
			Console.WriteLine("Введите срок гарантии (в месяцах): ");
			if (int.TryParse(Console.ReadLine(), out var answer)) return Math.Abs(answer);
			throw new Exception(nameof(answer));
		}

		private string GetCategoryCareRules()
		{
			Console.WriteLine("Введите правила новой категории: ");
			var rules = Console.ReadLine();
			return rules;
		}
	}
}