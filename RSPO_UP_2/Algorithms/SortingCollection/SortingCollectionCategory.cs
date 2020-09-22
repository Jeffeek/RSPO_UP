using System.Linq;
using RSPO_UP_2.View;

namespace RSPO_UP_2.Algorithms.SortingCollection
{
    public class SortingCollectionCategory
    {
        public void SortByCategoryName()
        {
            var list = DbCollectionHelper.GetCategories();
            var sortedList = list.OrderBy(x => x.CategoryName);
            ShowInfoView.PrintList(sortedList);
        }

        public void SortByGuaranteePeriod()
        {
            var list = DbCollectionHelper.GetCategories();
            var sortedList = list.OrderBy(x => x.GuaranteePeriod);
            ShowInfoView.PrintList(sortedList);
        }
    }
}
