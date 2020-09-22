using System.ComponentModel.DataAnnotations;

namespace RSPO_UP_2.EntityFramework.Models
{
    public class Category
    {
        [Key]
        public string CategoryName { get; set; }
        public int GuaranteePeriod { get; set; }
        public string CareRules { get; set; }

        public override string ToString()
        {
            return
                $"Название категории: {CategoryName} " +
                $"\nГарантийный период: {GuaranteePeriod}мес." +
                $"\nПравила ухода: {CareRules}";
        }
    }
}
