namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Cosmetics.Contracts;

    /// <summary>
    /// All toothpastes should implement the IToothpaste interface.
    /// </summary>
    internal class Toothpaste : Product, IToothpaste
    {
        private const int IngredientMinimumLength = 4;
        private const int IngredientMaximumLength = 12;

        private const string PrintIngredientsLine = "  * Ingredients: {0}";

        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = ingredients;
        }

        /// <summary>
        /// Ingredients should be represented as text,
        /// joined in their order of addition, separated by “, “ (comma and space).
        /// Each ingredient name’s length should be between 4 and 12 symbols, inclusive.
        /// The error message should be 
        /// "Each ingredient must be between {min} and {max} symbols long!".
        /// </summary>
        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }

            private set
            {
                this.ValidateIngredientsInput(value);

                this.ingredients = value;
            }
        }

        private void ValidateIngredientsInput(string value)
        {
            Validator.CheckIfNull(
                value,
                string.Format(
                    GlobalErrorMessages.StringCannotBeNullOrEmpty,
                    "Ingredients"));

            var ingredients = value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ingredient in ingredients)
            {
                ValidateProperties.ValidateStringNames(
                    ingredient,
                    Toothpaste.IngredientMinimumLength,
                    Toothpaste.IngredientMaximumLength,
                    "Each ingredient");
            }
        }

        /// <summary>
        ///   * Ingredients: EveryDay/Medical (when applicable)
        /// </summary>
        /// <returns></returns>
        public override string Print()
        {
            var printBuilder = new StringBuilder();

            printBuilder.Append(base.Print());
            printBuilder.AppendLine();
            printBuilder.AppendFormat(Toothpaste.PrintIngredientsLine, this.Ingredients);

            return printBuilder.ToString();
        }
    }
}
