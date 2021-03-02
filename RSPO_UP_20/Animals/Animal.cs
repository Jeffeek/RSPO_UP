using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSPO_UP_20.Animals
{
    [AnimalValidate]
    public abstract class Animal
    {
        protected Animal(double weight,
                         string name,
                         string wide,
                         int age
        )
        {
            Weight = weight;
            Name = name;
            Wide = wide;
            Age = age;
        }

        [Required]
        public string Name { get; }

        [Required]
        public string Wide { get; }

        [Required]
        public int Age { get; }

        [Required]
        public double Weight { get; }
    }
}
