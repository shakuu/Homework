
namespace Cosmetics.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using Contracts;

    public class Category : ICategory
    {
        // 0 name, 1 number of products
        // products / product
        private const string printFormat = 
            "{0} category – {1} {2} in total";

        private const string errorMsg = "Category name";
        // 0: prodcut name, 1: category name
        private const string ProductDoesNotExist = "Product {0} does not exist in category {1}!";

        private const int min = 2;
        private const int max = 15;

        private string name;

        private ICollection<IProduct> products;

        public Category(string name)
        {
            this.Name = name;

            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value, max, min,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength, errorMsg, min, max));

                Validator
                    .CheckIfStringIsNullOrEmpty(
                    value, 
                    string.Format(
                        GlobalErrorMessages
                        .StringCannotBeNullOrEmpty, "Name"));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
            this.Sort();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            var count =
                (from c in this.products
                 where c.Name == cosmetics.Name
                       && c.Brand == cosmetics.Brand
                       && c.Price == cosmetics.Price
                       && c.Gender == cosmetics.Gender
                 select c).Count();

            if (count < 1)
            {
                throw new ArgumentException(
                    string.Format(
                        ProductDoesNotExist,
                        cosmetics.Name,
                        this.Name));
            }

            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            var output = new StringBuilder();

            output.AppendFormat(
                printFormat,
                this.Name,
                this.products.Count,
                this.products.Count > 1 || this.products.Count == 0 ? 
                    "products" : "product");
            
            foreach (var product in this.products)
            {
                output.Append(Environment.NewLine);
                output.Append(product.Print());
            }

            return output.ToString();
        }

        private void Sort()
        {
            this.products =
                (from c in this.products
                 orderby c.Brand ascending, c.Price descending
                 select c).ToList();
        }
    }
}
