using System;
using System.Collections.Generic;
using System.Text;
using RSPO_UP_14.First_Task.Interfaces;

namespace RSPO_UP_14.FifthTask.ConcreteProducts
{
    public class Apple : ProductBase
    {
        public string Genus { get; }

        /// <inheritdoc />
        public Apple(string name, int quantity, string equipment, string genus) : base(name, quantity, equipment) => Genus = genus;
    }
}
