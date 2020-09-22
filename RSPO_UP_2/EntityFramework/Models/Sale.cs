using System.ComponentModel.DataAnnotations;

namespace RSPO_UP_2.EntityFramework.Models
{
    public class Sale
    {
        [Key]
        public int id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
        public string Date { get; set; }
        public Boot Product { get; set; }

        public override string ToString()
        {
            return $"id: {id} \n\tПродукт: {Product} Количество: {Count} Скидка: {Discount}% Дата покупки: {Date}";
        }
    }
}
