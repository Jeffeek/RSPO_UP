using System;
using System.Collections.Generic;
using System.Text;
using RSPO_UP_14.FifthTask.ConcreteProducts;
using RSPO_UP_14.First_Task.Interfaces;

namespace RSPO_UP_14.FifthTask.ConcreteFactories
{
    public class AppleFactory : ProductFactory
    {
        #region Overrides of ProductFactory<Apple>

        /// <inheritdoc />
        public override IProduct CreateInstance() => new Apple("Apple", 12, "yes", "White filling");

        #endregion
    }
}
