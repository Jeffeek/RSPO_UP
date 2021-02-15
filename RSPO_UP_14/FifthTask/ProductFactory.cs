using System;
using System.Collections.Generic;
using System.Text;
using RSPO_UP_14.First_Task.Interfaces;

namespace RSPO_UP_14.FifthTask
{
    public abstract class ProductFactory : IProductFactory
    {
        #region Implementation of IProductFactory<out TProduct>

        /// <inheritdoc />
        public abstract IProduct CreateInstance();

        #endregion
    }
}
