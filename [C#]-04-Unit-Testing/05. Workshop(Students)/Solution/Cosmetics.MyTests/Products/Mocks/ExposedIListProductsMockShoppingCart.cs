namespace Cosmetics.MyTests.Products.Mocks
{
    using System.Collections.Generic;

    using Cosmetics.Contracts;
    using Cosmetics.Products;

    internal class ExposedIListProductsMockShoppingCart
        : ShoppingCart
    {
        internal IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
