using System;
using System.Collections.Generic;
using System.Text;
using RSPO_UP_14.First_Task.Interfaces;

namespace RSPO_UP_14.FifthTask.ConcreteProducts
{
    public enum BananaColor
    {
        Green,
        Black,
        Yellow
    }

    public class Banana : ProductBase
    {
        public BananaColor Color { get; set; }

        /// <inheritdoc />
        public Banana(string name, int quantity, string equipment, BananaColor color) : base(name, quantity, equipment) => Color = color;
    }
}
