using System;
using System.Collections.Generic;
using System.Text;

namespace RSPO_UP_20.Animals
{
    [AnimalValidate]
    public class Dog : Animal
    {
        public string Pride { get; }

        /// <inheritdoc />
        public Dog(double weight, string name, string wide, int age, string pride) : base(weight, name, wide, age)
        {
            Pride = pride;
        }
    }
}
