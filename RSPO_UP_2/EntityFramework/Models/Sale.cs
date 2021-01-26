#region Using namespaces

using System.ComponentModel.DataAnnotations;

#endregion

namespace RSPO_UP_2.EntityFramework.Models
{
	public class Sale
	{
		[Key]
		public int Id { get; set; }

		public int ProductId { get; set; }
		public int Count { get; set; }
		public int Discount { get; set; }
		public string Date { get; set; }
		public Boot Product { get; set; }

		public override string ToString() =>
			$"id: {Id} \n\tПродукт: {Product} Количество: {Count} Скидка: {Discount}% Дата покупки: {Date}";
	}
}