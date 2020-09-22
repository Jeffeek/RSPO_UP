using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.EntityFramework.Models;

namespace RSPO_UP_2.Algorithms
{
    public static class DbCollectionHelper
    {
        public static List<Boot> GetBoots()
        {
            List<Boot> list;
            using (var db = new BootsContext())
            {
                db.Categories.Load();
                db.Boots.Load();
                list = db.Boots.ToList();
            }

            return list;
        }

        public static List<Category> GetCategories()
        {
            List<Category> list;
            using (var db = new BootsContext())
            {
                db.Categories.Load();
                list = db.Categories.ToList();
            }

            return list;
        }

        public static List<Sale> GetSales()
        {
            List<Sale> list;
            using (var db = new BootsContext())
            {
                db.Categories.Load();
                db.Boots.Load();
                db.Sales.Load();
                list = db.Sales.ToList();
            }

            return list;
        }
    }
}
