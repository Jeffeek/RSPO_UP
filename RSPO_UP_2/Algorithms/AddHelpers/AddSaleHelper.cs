using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.EntityFramework.Models;
using RSPO_UP_2.View;

namespace RSPO_UP_2.Algorithms.AddHelpers
{
    public class AddSaleHelper
    {
        private bool UpdateDataBase(Sale newelem)
        {
            int result = -1;
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

        public AddSaleHelper()
        {
            TakeData();
        }

        private void TakeData()
        {
            int prodId = GetProductId();
            int count = GetCount();
            int discount = GetDiscount();
            string data = GetData();
            Sale sale = new Sale()
            {
                Count = count,
                ProductId = prodId,
                Date = data,
                Discount = discount
            };
            if (UpdateDataBase(sale))
            {
                Console.WriteLine("Добавление произошло удачно!");
            }
            else
            {
                Console.WriteLine("Добавление произошло НЕ удачно!");
            }
        }

        private int GetProductId()
        {
            var boot = DbCollectionHelper.GetBoots();
            Console.WriteLine("Выберите id товара.\nСписок товара: ");
            ShowInfoView.PrintList(boot);
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                var bo = boot.SingleOrDefault(x => x.id == answer);
                if (bo?.Count == 0)
                    throw new Exception("Товара нет на складе");
                if (bo != null)
                {
                    return bo.id;
                }
            }
            throw new Exception("Ошибка добавления чека, видимо нет такого товара");
        }

        private int GetCount()
        {
            Console.WriteLine("Введите количество товара в чеке: ");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                return Math.Abs(answer);
            }
            throw new InvalidCastException("Были введены некорректные данные, нужен был числовой ввод");
        }

        private int GetDiscount()
        {
            Console.WriteLine("Введите скидку на товар в чеке: ");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                return Math.Abs(answer);
            }
            throw new InvalidCastException("Были введены некорректные данные, нужен был числовой ввод");
        }

        private string GetData()
        {
            Console.WriteLine("Введите дату покупки в формате: mm.dd.yy: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
            {
                return result.ToShortDateString();
            }
            throw new InvalidCastException("Были введены некорректные данные, нужен был тип данных: дата");
        }
    }
}
