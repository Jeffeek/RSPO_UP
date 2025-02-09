﻿#region Using namespaces

using System;
using System.Linq;
using RSPO_UP_2.View;

#endregion

namespace RSPO_UP_2.Algorithms.SortingCollection
{
	public class SortingCollectionSale
	{
		public void SortByDate()
		{
			var list = DbCollectionHelper.GetSales();
			var sortedList = list.OrderBy(x => DateTime.Parse(x.Date));
			ShowInfoView.PrintList(sortedList);
		}

		public void SortByDiscount()
		{
			var list = DbCollectionHelper.GetSales();
			var sortedList = list.OrderBy(x => x.Discount);
			ShowInfoView.PrintList(sortedList);
		}

		public void SortByCount()
		{
			var list = DbCollectionHelper.GetSales();
			var sortedList = list.OrderBy(x => x.Count);
			ShowInfoView.PrintList(sortedList);
		}

		public void SortByTypedRangeDiscount(int start, int end)
		{
			var list = DbCollectionHelper.GetSales();
			var sortedList = list.FindAll(x => x.Discount >= start && x.Discount <= end);
			ShowInfoView.PrintList(sortedList);
		}

		public void SortByTypedDiscount(int discount)
		{
			SortByTypedRangeDiscount(discount, discount);
		}
	}
}