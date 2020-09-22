using System;
using System.Linq;
using RSPO_UP_2.View;

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
    }
}
