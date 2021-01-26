#region Using namespaces

using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.EntityFramework.Models;
using RSPO_UP_2.View;

#endregion

namespace RSPO_UP_2.Algorithms.AddHelpers
{
	public class AddSaleHelper
	{
		public AddSaleHelper()
		{
			TakeData();
		}

		private bool UpdateDataBase(Sale newelem)
		{
			int result;
			try
			{
				using (var db = new BootsContext())
				{
					db.Sales.Load();
					db.Sales.Add(newelem);
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
			var prodId = GetProductId();
			var count = GetCount();
			var discount = GetDiscount();
			var data = GetData();
			var sale = new Sale
			           {
				           Count = count,
				           ProductId = prodId,
				           Date = data,
				           Discount = discount
			           };

			if (UpdateDataBase(sale))
				Console.WriteLine("Добавление произошло удачно!");
			else
				Console.WriteLine("Добавление произошло НЕ удачно!");
		}

		private int GetProductId()
		{
			var boot = DbCollectionHelper.GetBoots();
			Console.WriteLine("Выберите id товара.\nСписок товара: ");
			ShowInfoView.PrintList(boot);
			if (int.TryParse(Console.ReadLine(), out var answer))
			{
				var bo = boot.SingleOrDefault(x => x.Id == answer);
				if (bo?.Count == 0)
					throw new Exception("Товара нет на складе");

				if (bo != null) return bo.Id;
			}

			throw new Exception("Ошибка добавления чека, видимо нет такого товара");
		}

		private int GetCount()
		{
			Console.WriteLine("Введите количество товара в чеке: ");
			if (int.TryParse(Console.ReadLine(), out var answer)) return Math.Abs(answer);
			throw new InvalidCastException("Были введены некорректные данные, нужен был числовой ввод");
		}

		private int GetDiscount()
		{
			Console.WriteLine("Введите скидку на товар в чеке: ");
			if (int.TryParse(Console.ReadLine(), out var answer)) return Math.Abs(answer);
			throw new InvalidCastException("Были введены некорректные данные, нужен был числовой ввод");
		}

		private string GetData()
		{
			Console.WriteLine("Введите дату покупки в формате: mm.dd.yy: ");
			if (DateTime.TryParse(Console.ReadLine(), out var result)) return result.ToShortDateString();
			throw new InvalidCastException("Были введены некорректные данные, нужен был тип данных: дата");
		}
	}
}