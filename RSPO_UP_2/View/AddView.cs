using System;
using RSPO_UP_2.Algorithms.AddHelpers;

namespace RSPO_UP_2.View
{
    public class AddView
    {
        public AddView()
        {
            SelectAdding();
        }

        private void SelectAdding()
        {
            Console.WriteLine("1. Добавить новый продукт");
            Console.WriteLine("2. Добавить новую категорию");
            Console.WriteLine("3. Добавить новую покупку");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                switch (answer)
                {
                    case 1:
                    {
                        AddBootHelper helper = new AddBootHelper();
                        break;
                    }

                    case 2:
                    {
                        AddCategoryHelper helper = new AddCategoryHelper();
                        break;
                    }

                    case 3:
                    {
                        AddSaleHelper helper = new AddSaleHelper();
                        break;
                    }
                }
            }
        }
    }
}
