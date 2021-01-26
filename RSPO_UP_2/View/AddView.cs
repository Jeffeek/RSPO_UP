#region Using namespaces

using System;
using RSPO_UP_2.Algorithms.AddHelpers;

#endregion

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
			if (int.TryParse(Console.ReadLine(), out var answer))
			{
				switch (answer)
				{
					case 1:
					{
						var dummy = new AddBootHelper();
						break;
					}

					case 2:
					{
						var dummy = new AddCategoryHelper();
						break;
					}

					case 3:
					{
						var dummy = new AddSaleHelper();
						break;
					}
				}
			}
		}
	}
}