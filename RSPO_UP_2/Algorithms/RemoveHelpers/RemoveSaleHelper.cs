#region Using namespaces

using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.View;

#endregion

namespace RSPO_UP_2.Algorithms.RemoveHelpers
{
	public class RemoveSaleHelper
	{
		public RemoveSaleHelper()
		{
			Remove();
		}

		public bool UpdateDataBase(int id)
		{
			int result;
			using (var db = new BootsContext())
			{
				db.Sales.Load();
				var elem = db.Sales.First(x => x.Id == id);
				db.Sales.Remove(elem);
				result = db.SaveChanges();
			}

			return result == 1;
		}

		private int GetId()
		{
			int id;
			Console.WriteLine("Удаляем чек покупки");
			var list = DbCollectionHelper.GetSales();
			ShowInfoView.PrintList(list);
			Console.WriteLine("Введите id: ");
			if (int.TryParse(Console.ReadLine(), out id))
			{
				if (list.Select(x => x.Id).Contains(id))
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