using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.View;

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
            int result = -1;
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
            int id = -1;
            Console.WriteLine("Удаляем категорию");
            var bootslist = DbCollectionHelper.GetBoots();
            var categorieslist = DbCollectionHelper.GetCategories();
            ShowInfoView.PrintList(categorieslist);
            Console.WriteLine("Введите название категории: ");
            var name = Console.ReadLine();
            bool isUsedCategory = bootslist
                                        .Select(x => x.Category.CategoryName)
                                        .Contains(name);
            bool isExists = categorieslist.FirstOrDefault(x => x.CategoryName == name) != null;

            if (!isUsedCategory && isExists)
                return name;

            if (isUsedCategory)
            {
                Console.WriteLine("Данная категория используется товарами, сначала удалите товары");
            }

            if (!isExists)
            {
                Console.WriteLine("Данная категория не найдена");
            }

            throw new Exception();
        }

        private void Remove()
        {
            string categoryName = GetCategoryName();
            UpdateDataBase(categoryName);
        }
    }
}
