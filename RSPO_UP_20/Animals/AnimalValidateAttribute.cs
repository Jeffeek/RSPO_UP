using System;
using System.ComponentModel.DataAnnotations;

namespace RSPO_UP_20.Animals
{
	internal class AnimalValidateAttribute : ValidationAttribute
	{
		#region Overrides of ValidationAttribute

		/// <inheritdoc />
		public override bool IsValid(object value) => value switch
													  {
															  null => false,
															  Animal animal => Char.IsUpper(animal.Name[0])
																			   && value.GetType().BaseType == typeof(Animal)
																			   && animal.Weight > 0,
															  _ => false
													  };

		#endregion
	}
}
