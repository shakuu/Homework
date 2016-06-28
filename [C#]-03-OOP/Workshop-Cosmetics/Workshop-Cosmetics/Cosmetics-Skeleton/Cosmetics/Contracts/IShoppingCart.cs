namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    public interface IShoppingCart
    {
        ICollection<IProduct> ProductList { get; set; }

        void AddProduct(IProduct product);

        bool ContainsProduct(IProduct product);

        decimal TotalPrice();
    }
}