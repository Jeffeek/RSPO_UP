using System;
using System.Data.Entity;
using System.Linq;
using RSPO_UP_2.EntityFramework;
using RSPO_UP_2.View;

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
            int result = -1;
            using (var db = new BootsContext())
            {
                db.Boots.Load();
                var elem = db.Boots.First(x => x.id == id);
                db.Boots.Remove(elem);
                result = db.SaveChanges();
            }

            return result == 1;
        }

        private int GetId()
        {
            int id = -1;
            Console.WriteLine("Удаляем продукт");
            var bootslist = DbCollectionHelper.GetBoots();
            var saleslist = DbCollectionHelper.GetSales();
            ShowInfoView.PrintList(bootslist);
            Console.WriteLine("Введите id: ");
            if (int.TryParse(Console.ReadLine(), out id))
            {
                bool bootsContains = bootslist
                                            .Select(x => x.id)
                                            .Contains(id);
                bool isThereNoSales = saleslist
                                            .Select(x => x.Product)
                                            .SingleOrDefault(x => x.id == id) == null;
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
            int id = GetId();
            UpdateDataBase(id);
        }
    }
}
