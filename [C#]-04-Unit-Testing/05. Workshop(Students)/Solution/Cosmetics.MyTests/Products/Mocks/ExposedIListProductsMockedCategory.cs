namespace Cosmetics.MyTests.Products.Mocks
{
    using System.Collections.Generic;

    using Cosmetics.Contracts;
    using Cosmetics.Products;

    internal class ExposedIListProductsMockedCategory : Category
    {
        internal ExposedIListProductsMockedCategory(string name)
            : base(name)
        {
        }

        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
