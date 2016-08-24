namespace Bunnies.Utils
{
    using System.Text;

    public static class StringExtensions
    {
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
