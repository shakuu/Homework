namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System.Collections.Generic;

    public class Toothpaste : Product, IProduct, IToothpaste
    {
        private const string PrintFormat =
            "- {0} - {1}:\r\n  * Price: ${2}\r\n  * For gender: {3}\r\n  * Ingredients: {4}";

        private const string PrintFormatLine1 = "  * Ingredients: {0}";


        private ICollection<string> ingredientsLCollection;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, ICollection<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.ingredientsLCollection = new List<string>();
            this.ingredientsLCollection = ingredients;
        }

        public string Ingredients
        {
            get { return string.Join(", ", this.ingredientsLCollection); }
        }

        private ICollection<string> IngredientsCollection
        {
            get
            {
                return this.ingredientsLCollection;
            }
            set
            {
                // Valdiate
                foreach (var str in value)
                {
                    Validator.CheckIfStringLengthIsValid(
                        str, 
                        GlobalValidationConstants.ToothpasteIngredientNameLengthMax,
                        GlobalValidationConstants.ToothpasteIngredientNameLengthMin,
                        string.Format(
                            GlobalErrorMessages.IncorrectIngredientNameLength,
                            GlobalValidationConstants.ToothpasteIngredientNameLengthMin,
                            GlobalValidationConstants.ToothpasteIngredientNameLengthMax));

                    Validator.CheckIfStringIsNullOrEmpty(
                        str, 
                        string.Format(
                            GlobalErrorMessages.StringCannotBeNullOrEmpty,
                            "Ingredients"));
                }

                this.ingredientsLCollection = value;
            }
        }
        
        public override string Print()
        {
            return base.Print()
                   + string.Format(PrintFormatLine1, this.Ingredients);
        }
    }
}