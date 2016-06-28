
namespace Cosmetics.Categories
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Category : ICategory
    {
        // 0 name, 1 number of products
        // products / product
        private const string PrintFormat = "{0} category - {1} {2} in total";
        private const string ErrorMsg = "Category name";
        private const string ProductSingle = "product";
        private const string ProductPlural = "products";

        private const int Min = 2;
        private const int Max = 15;

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
                    value,
                    GlobalValidationConstants.CategoryNameLengthMax,
                    GlobalValidationConstants.CategoryNameLengthMin,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength, ErrorMsg, Min, Max));

                Validator
                    .CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages
                        .StringCannotBeNullOrEmpty, ErrorMsg));

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
            var count = this.CountElementOccurances(cosmetics);

            if (count < 1)
            {
                throw new ArgumentException(
                    string.Format(
                        GlobalErrorMessages.ProductDoesNotExist,
                        cosmetics.Name,
                        this.Name));
            }

            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            var output = new StringBuilder();

            output.AppendFormat(
                PrintFormat,
                this.Name,
                this.products.Count,
                this.products.Count > 1 || this.products.Count == 0 ?
                    ProductPlural : ProductSingle);

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

        private int CountElementOccurances(IProduct cosmetics)
        {
            return
                (from c in this.products
                 where c.Name == cosmetics.Name
                       && c.Brand == cosmetics.Brand
                       && c.Price == cosmetics.Price
                       && c.Gender == cosmetics.Gender
                 select c).Count();
        }
    }
}
