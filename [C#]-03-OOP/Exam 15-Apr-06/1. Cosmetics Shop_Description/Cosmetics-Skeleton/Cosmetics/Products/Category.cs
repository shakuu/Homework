namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Contracts;
    using Cosmetics.Common;

    /// <summary>
    /// Categories should implement ICategory.
    /// Adding the same product to one category more than once is allowed.
    /// </summary>
    public class Category : ICategory
    {
        private const string ProductNotFoundErrorMessage = "Product {0} does not exist in category {1}!";
        private const string PrintHeaderLineFormat = "{0} category - {1} {2} in total";

        private const int NameMinimumLength = 2;
        private const int NameMaximumLength = 15;

        private string name;

        private ICollection<IProduct> products;

        public Category(string name)
        {
            this.products = new LinkedList<IProduct>();

            this.Name = name;
        }

        /// <summary>
        /// Minimum category name’s length length is 2 symbols
        /// and maximum is 15 symbols.
        /// he error message should be
        /// "Category name must be between {min} and {max} symbols long!".
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                ValidateProperties.ValidateStringNames(
                    value,
                    Category.NameMinimumLength,
                    Category.NameMaximumLength,
                    "Category name");

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.CheckIfInputParamIsNull(cosmetics);

            this.products.Add(cosmetics);

            this.products = this.SortCollectionOfProducts(this.products);
        }

        /// <summary>
        /// Category’s print method should return text in the following format:
        /// Included in .DOC file
        /// {category name} category – {number of products} products/product in total
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            // TODO: 
            var printBuilder = new StringBuilder();

            printBuilder.AppendFormat(
                Category.PrintHeaderLineFormat,
                this.Name,
                this.products.Count,
                this.products.Count == 1 ? "product" : "products");

            foreach (var product in this.products)
            {
                printBuilder.AppendFormat(Environment.NewLine);
                printBuilder.Append(product.Print());
            }

            return printBuilder.ToString();
        }

        /// <summary>
        /// When removing product from category, 
        /// if the product is not found, 
        /// error message should be 
        /// </summary>
        /// <param name="cosmetics"></param>
        public void RemoveCosmetics(IProduct cosmetics)
        {
            this.CheckIfInputParamIsNull(cosmetics);

            this.CheckIfProductExistsInThisCategory(cosmetics, this.products);

            this.products.Remove(cosmetics);

            this.products = this.SortCollectionOfProducts(this.products);
        }

        /// <summary>
        /// "Product {product name} does not exist in category {category name}!".
        /// </summary>
        /// <param name="product"></param>
        /// <param name="collection"></param>
        private void CheckIfProductExistsInThisCategory(IProduct product, ICollection<IProduct> collection)
        {
            var searchResult = collection.Contains(product);

            if (searchResult == false)
            {
                throw new ArgumentException(
                    string.Format(
                        Category.ProductNotFoundErrorMessage,
                        product.Name,
                        this.Name));
            }
        }

        /// <summary>
        /// Products in category should be sorted by brand in ascending order
        /// and then by price in descending order.
        /// </summary>
        private ICollection<IProduct> SortCollectionOfProducts(IEnumerable<IProduct> collection)
        {
            var sortedProducts =
                (from product in collection
                 orderby product.Brand ascending,
                         product.Price descending
                 select product).ToList();

            return sortedProducts;
        }

        /// <summary>
        /// DRY!
        /// </summary>
        /// <param name="cosmetics"></param>
        private void CheckIfInputParamIsNull(IProduct cosmetics)
        {
            var cosmeticsIsNullErrorMessage = string.Format(GlobalErrorMessages.ObjectCannotBeNull, "cosmetics");

            Validator.CheckIfNull(cosmetics, cosmeticsIsNullErrorMessage);
        }
    }
}
