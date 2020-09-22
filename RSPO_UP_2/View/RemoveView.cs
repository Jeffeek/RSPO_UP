using System;
using RSPO_UP_2.Algorithms.RemoveHelpers;

namespace RSPO_UP_2.View
{
    public class RemoveView
    {
        public RemoveView()
        {
            SelectRemoving();
        }

        private void SelectRemoving()
        {
            Console.WriteLine("1. Удалить продукт");
            Console.WriteLine("2. Удалить категорию");
            Console.WriteLine("3. Удалить покупку");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                switch (answer)
                {
                    case 1:
                    {
                        RemoveBootHelper helper = new RemoveBootHelper();
                        break;
                    }

                    case 2:
                    {
                        RemoveCategoryHelper helper = new RemoveCategoryHelper();
                        break;
                    }

                    case 3:
                    {
                        RemoveSaleHelper helper = new RemoveSaleHelper();
                        break;
                    }
                }
            }
        }
    }
}
