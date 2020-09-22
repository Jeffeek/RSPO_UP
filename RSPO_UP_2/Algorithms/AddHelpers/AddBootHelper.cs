using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.EntityFramework.Models;
using RSPO_UP_2.View;

namespace RSPO_UP_2.Algorithms.AddHelpers
{
    public class AddBootHelper
    {
        private bool UpdateDataBase(Boot newboot)
        {
            int result = -1;
            try
            {
                using (var db = new BootsContext())
                {
                    db.Boots.Load();
                    db.Boots.Add(newboot);
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

        public AddBootHelper()
        {
            GetData();
        }

        private void GetData()
        {
            var name = GetProductName();
            var price = GetPrice();
            var count = GetCount();
            var categoryName = GetCategoryName();
            Boot boot = new Boot()
            {
                CategoryName = categoryName,
                Count = count,
                Price = price,
                ProductName = name
            };
            UpdateDataBase(boot);
        }

        private string GetProductName()
        {
            var list = DbCollectionHelper.GetBoots();
            Console.WriteLine("Введите название продукта: ");
            var name = Console.ReadLine();
            if (!list.Select(x => x.ProductName).Contains(name))
            {
                return name;
            }
            throw new Exception(nameof(name));
        }

        private int GetPrice()
        {
            Console.WriteLine("Введите цену продукта: ");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                return Math.Abs(answer);
            }
            throw new InvalidCastException();
        }

        private int GetCount()
        {
            Console.WriteLine("Введите количество товара на складе: ");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                return Math.Abs(answer);
            }

            return 1;
        }

        private string GetCategoryName()
        {
            var list = DbCollectionHelper.GetCategories();
            Console.WriteLine("Выберите одну из категорий(введите с клавиатуры): ");
            ShowInfoView.PrintList(list);
            var categoryName = Console.ReadLine();
            if (list.Select(x => x.CategoryName).Contains(categoryName))
            {
                return categoryName;
            }

            throw new Exception();
        }
    }
}
