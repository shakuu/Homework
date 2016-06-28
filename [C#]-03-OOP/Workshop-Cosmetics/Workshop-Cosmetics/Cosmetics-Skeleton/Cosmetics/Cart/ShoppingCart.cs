
namespace Cosmetics.Cart
{
    using Cosmetics.Contracts;
    using System.Collections.Generic;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.productList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
            set { productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            this.ProductList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.productList.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal output = 0;

            foreach (var product in this.ProductList)
            {
                output += product.Price;
            }

            return output;
        }
    }
}
