using System;

namespace ProductsOrderedBag
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return (int)(this.Price - other.Price);
        }
    }
}
