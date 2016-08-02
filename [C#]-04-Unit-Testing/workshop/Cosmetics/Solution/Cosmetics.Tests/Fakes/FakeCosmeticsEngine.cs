namespace Cosmetics.Tests.Fakes
{
    using System.Collections.Generic;

    using Cosmetics. Contracts;
    using Cosmetics.Engine;

    internal class FakeCosmeticsEngine : CosmeticsEngine
    {


        public FakeCosmeticsEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart) 
            : base(factory, shoppingCart)
        {
        }

        internal IDictionary<string, ICategory> BaseCategories
        {
            get
            {
                return base.categories;
            }
        }

        internal IDictionary<string, IProduct> BaseProducts
        {
            get
            {
                return base.products;
            }
        }
    }
}
