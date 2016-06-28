namespace Cosmetics.Common
{
    public class GlobalErrorMessages
    {
        public const string StringCannotBeNullOrEmpty = "{0} cannot be null or empty!";
        public const string ObjectCannotBeNull = "{0} cannot be null!";
        public const string InvalidStringLength = "{0} must be between {1} and {2} symbols long!";
        public const string PriceNegativeMessage = "Price must be positive";

        public const string IncorrectIngredientNameLength =
            "Each ingredient must be between {0} and {1} symbols long!";

        public const string ProductDoesNotExist =
            "Product {0} does not exist in category {1}!";
    }
}
