using System.Collections.Generic;
using System.Linq;
using RSPO_UP_2.EntityFramework.Models;
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

        public void SortByTypedCategoryName(string name)
        {
            var list = DbCollectionHelper.GetCategories();
            var sortedList = new List<Category> {list.Find(x => x.CategoryName == name)};
            ShowInfoView.PrintList(sortedList);
        }
    }
}
