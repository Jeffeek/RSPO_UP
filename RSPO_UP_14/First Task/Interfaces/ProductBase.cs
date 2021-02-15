#region Using derectives

using System;

#endregion

namespace RSPO_UP_14.First_Task.Interfaces
{
    public abstract class ProductBase : IProduct, IEquatable<IProduct>
    {
        protected ProductBase(string name, int quantity, string equipment)
        {
            Name = name;
            Quantity = quantity;
            Equipment = equipment;
            HashCode = GetHashCode();
        }

        #region Implementation of IProduct

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public int HashCode { get; }

        /// <inheritdoc />
        public int Quantity { get; set; }

        /// <inheritdoc />
        public string Equipment { get; }

        /// <inheritdoc />
        public bool DecreaseQuantity()
        {
            if (Quantity == 0) return false;
            Quantity--;

            return true;
        }

        #endregion

        #region Equality members

        public bool Equals(IProduct other) => Name == other?.Name &&
                                              HashCode == other?.HashCode &&
                                              Quantity == other.Quantity &&
                                              Equipment == other.Equipment;

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((ProductBase)obj);
        }

        /// <inheritdoc />
        public sealed override int GetHashCode() => System.HashCode.Combine(Name, Equipment);

        #endregion
    }
}