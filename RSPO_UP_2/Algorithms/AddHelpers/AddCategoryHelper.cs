using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.EntityFramework.Models;

namespace RSPO_UP_2.Algorithms.AddHelpers
{
    public class AddCategoryHelper
    {
        private bool UpdateDataBase(Category newcategory)
        {
            int result = -1;
            try
            {
                using (var db = new BootsContext())
                {
                    db.Categories.Load();
                    db.Categories.Add(newcategory);
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

        public AddCategoryHelper()
        {
            TakeData();
        }

        private void TakeData()
        {
            string name = GetName();
            string rules = GetCategoryCareRules();
            int guarantee = GetGuaranteePeriod();
            Category category = new Category()
            {
                CareRules = rules,
                CategoryName = name,
                GuaranteePeriod = guarantee
            };

            if (UpdateDataBase(category))
            {
                Console.WriteLine("Добавление произошло удачно!");
            }
            else
            {
                Console.WriteLine("Добавление произошло НЕ удачно!");
            }
        }

        private string GetName()
        {
            var list = DbCollectionHelper.GetCategories();
            Console.WriteLine("Введите название новой категории: ");
            string name = Console.ReadLine();
            if (!list.Select(x => x.CategoryName).Contains(name))
            {
                return name;
            }
            throw new Exception(nameof(name));
        }

        private int GetGuaranteePeriod()
        {
            Console.WriteLine("Введите срок гарантии (в месяцах): ");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                return Math.Abs(answer);
            }
            throw new Exception(nameof(answer));
        }

        private string GetCategoryCareRules()
        {
            Console.WriteLine("Введите правила новой категории: ");
            string rules = Console.ReadLine();
            return rules;
        }
    }
}
