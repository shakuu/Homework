namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;

    using Cosmetics.Contracts;
    using Common;

    /// <summary>
    /// Shopping cart should implement the IShoppingCart interface.
    /// Adding the same product more than once is allowed. 
    /// Do not check if the product exists, when removing it from the shopping cart.
    /// </summary>
    internal class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> products;

        public ShoppingCart()
        {
            this.products = new LinkedList<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            this.CheckIfInputParamIsNull(product);
            var searchResult = this.products.Contains(product);
            return searchResult;
        }

        public void RemoveProduct(IProduct product)
        {
            this.CheckIfInputParamIsNull(product);
            this.products.Remove(product);
        }

        public decimal TotalPrice()
        {
            var result = 0m;
            foreach (var product in this.products)
            {
                result += product.Price;
            }
            return result;
        }

        /// <summary>
        /// DRY!
        /// </summary>
        /// <param name="cosmetics"></param>
        private void CheckIfInputParamIsNull(IProduct cosmetics)
        {
            var cosmeticsIsNullErrorMessage = string.Format(GlobalErrorMessages.ObjectCannotBeNull, "product");

            Validator.CheckIfNull(cosmetics, cosmeticsIsNullErrorMessage);
        }
    }
}
