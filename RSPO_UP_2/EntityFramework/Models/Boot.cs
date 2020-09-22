using System.ComponentModel.DataAnnotations;

namespace RSPO_UP_2.EntityFramework.Models
{
    public class Boot
    {
        [Key]
        public int id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return $"id : {id} \nНазвание: {ProductName} \nЦена: {Price} \nКоличество: {Count} \n\tКатегория: {Category}";
        }
    }
}
