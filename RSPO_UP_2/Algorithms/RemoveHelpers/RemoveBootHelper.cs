#region Using namespaces

using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.View;

#endregion

namespace RSPO_UP_2.Algorithms.RemoveHelpers
{
	public class RemoveBootHelper
	{
		public RemoveBootHelper()
		{
			Remove();
		}

		public bool UpdateDataBase(int id)
		{
			int result;
			using (var db = new BootsContext())
			{
				db.Boots.Load();
				var elem = db.Boots.First(x => x.Id == id);
				db.Boots.Remove(elem);
				result = db.SaveChanges();
			}

			return result == 1;
		}

		private int GetId()
		{
			int id;
			Console.WriteLine("Удаляем продукт");
			var bootslist = DbCollectionHelper.GetBoots();
			var saleslist = DbCollectionHelper.GetSales();
			ShowInfoView.PrintList(bootslist);
			Console.WriteLine("Введите id: ");
			if (int.TryParse(Console.ReadLine(), out id))
			{
				var bootsContains = bootslist
				                    .Select(x => x.Id)
				                    .Contains(id);

				var isThereNoSales = saleslist
				                     .Select(x => x.Product)
				                     .SingleOrDefault(x => x.Id == id) ==
				                     null;

				if (!bootsContains)
				{
					Console.WriteLine("Такого id нет!");
					throw new Exception();
				}

				if (!isThereNoSales)
				{
					Console.WriteLine("Есть чеки с данным товаром, сначала удалите чеки!");
					throw new Exception();
				}

				return id;
			}

			throw new Exception();
		}

		private void Remove()
		{
			var id = GetId();
			UpdateDataBase(id);
		}
	}
}