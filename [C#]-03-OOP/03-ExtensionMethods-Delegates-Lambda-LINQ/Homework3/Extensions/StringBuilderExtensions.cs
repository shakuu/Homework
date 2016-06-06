
namespace Homework3.Extensions
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring
            (this StringBuilder stringBuilder, int index, int length)
        {
            if (index+length > stringBuilder.Length
                || index >= stringBuilder.Length
                || index < 0 )
            {
                throw new IndexOutOfRangeException("");
            }

            var output = new StringBuilder();

            for (int i = index; i < index+length; i++)
            {
                output.Append(stringBuilder[i]);
            }

            return output;
        }

        public static StringBuilder Substring
            (this StringBuilder stringBuilder, int index)
        {
            if (index >= stringBuilder.Length
                || index < 0)
            {
                throw new IndexOutOfRangeException("");
            }

            var output = new StringBuilder();

            for (int i = index; i < stringBuilder.Length; i++)
            {
                output.Append(stringBuilder[i]);
            }

            return output;
        }
    }
}
