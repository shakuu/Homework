namespace Bunnies.Utils
{
    using System.Text;

    /// <summary>
    /// Provides extension methods for custom string manipulation.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Inserts whitespace in a string:
        /// "ThisString" -> "This String"
        /// </summary>
        /// <param name="inputString"> The string to parse. </param>
        /// <returns> Returns a new string with inserted whitespace before capital letters. </returns>
        public static string SplitToSeparateWordsByUppercaseLetter(this string inputString)
        {
            const char SingleWhitespace = ' ';
            var stringBuilder = new StringBuilder();

            foreach (var letter in inputString)
            {
                if (char.IsUpper(letter))
                {
                    stringBuilder.Append(SingleWhitespace);
                }

                stringBuilder.Append(letter);
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
