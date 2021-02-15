using System;
using System.Collections.Generic;
using System.Text;
using RSPO_UP_14.FifthTask.ConcreteProducts;
using RSPO_UP_14.First_Task.Interfaces;

namespace RSPO_UP_14.FifthTask.ConcreteFactories
{
    public class BananaFactory : ProductFactory
    {
        #region Overrides of ProductFactory<Banana>

        /// <inheritdoc />
        public override IProduct CreateInstance() => new Banana("Banana", 55, "no", BananaColor.Black);

        #endregion
    }
}
