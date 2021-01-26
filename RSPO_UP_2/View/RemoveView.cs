#region Using namespaces

using System;
using RSPO_UP_2.Algorithms.RemoveHelpers;

#endregion

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
			if (int.TryParse(Console.ReadLine(), out var answer))
			{
				switch (answer)
				{
					case 1:
					{
						var dummy = new RemoveBootHelper();
						break;
					}

					case 2:
					{
						var dummy = new RemoveCategoryHelper();
						break;
					}

					case 3:
					{
						var dummy = new RemoveSaleHelper();
						break;
					}
				}
			}
		}
	}
}