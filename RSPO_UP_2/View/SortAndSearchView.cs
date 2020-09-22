using System;
using RSPO_UP_2.Algorithms.SortingCollection;

namespace RSPO_UP_2.View
{
    public class SortAndSearchView
    {
        public SortAndSearchView()
        {
            SelectModel();
        }

        private void SelectModel()
        {
            Console.WriteLine("1. Сортировка обуви");
            Console.WriteLine("2. Сортировка категорий");
            Console.WriteLine("3. Сортировка продаж");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                switch (answer)
                {
                    case 1:
                    {
                        BootSorting();
                        break;
                    }

                    case 2:
                    {
                        CategorySorting();
                        break;
                    }

                    case 3:
                    {
                        SaleSorting();
                        break;
                    }
                }
            }
        }

        private void BootSorting()
        {
            var sortBoots = new SortingCollectionBoots();
            Console.WriteLine("1. Сортировка по цене");
            Console.WriteLine("2. Сортировка по количеству");
            Console.WriteLine("3. Сортировка по названию категории");
            Console.WriteLine("4. Сортировка по названию");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                switch (answer)
                {
                    case 1:
                    {
                        sortBoots.SortByPrice();
                        break;
                    }

                    case 2:
                    {
                        sortBoots.SortByCount();
                        break;
                    }

                    case 3:
                    {
                        sortBoots.SortByCategoryName();
                        break;
                    }

                    case 4:
                    {
                        sortBoots.SortByName();
                        break;
                    }
                }
            }
        }

        private void CategorySorting()
        {
            var sortBoots = new SortingCollectionCategory();
            Console.WriteLine("1. Сортировка по названию");
            Console.WriteLine("2. Сортировка по гарантийному сроку");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                switch (answer)
                {
                    case 1:
                    {
                        sortBoots.SortByCategoryName();
                        break;
                    }

                    case 2:
                    {
                        sortBoots.SortByGuaranteePeriod();
                        break;
                    }
                }
            }
        }

        private void SaleSorting()
        {
            var sortBoots = new SortingCollectionSale();
            Console.WriteLine("1. Сортировка по дате");
            Console.WriteLine("2. Сортировка по скидке");
            Console.WriteLine("3. Сортировка по количеству товара");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                switch (answer)
                {
                    case 1:
                    {
                        sortBoots.SortByDate();
                        break;
                    }

                    case 2:
                    {
                        sortBoots.SortByDiscount();
                        break;
                    }

                    case 3:
                    {
                        sortBoots.SortByCount();
                        break;
                    }
                }
            }
        }
    }
}
