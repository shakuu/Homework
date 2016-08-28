//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extensions providing commonly used operations on strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Get MD5 hash of the string.
        /// </summary>
        /// <param name="input"> The string to perform the operation on. </param>
        /// <returns> A string representing the MD5 hash. </returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Determines whether the string contains a true-like value.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <returns> True if the string contains a true-like value. </returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            var containsInput = stringTrueValues.Contains(input.ToLower());
            return containsInput;
        }

        /// <summary>
        /// Attempt to parse the string to short.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <returns> The parsed value or zero. </returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Attempt to parse the string to integer.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <returns> The parsed value or zero. </returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Attempt to parse the string to long.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <returns> The parsed value or zero. </returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Attempt to parse the string to DateTime.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <returns> The parsed value. </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalize the first letter in a string.
        /// </summary>
        /// <param name="input"> String to the operation on. </param>
        /// <returns> A new string with a capitalized first letter. </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var capitalizedString = input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
            return capitalizedString;
        }

        /// <summary>
        /// Extract a string between startString and endString, starting at position startFrom.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <param name="startString"> Extracts the string starting at the first occurrence of startString. </param>
        /// <param name="endString"> Extracts the string ending at the first occurrence of endString. </param>
        /// <param name="startFrom"> Evaluates the input string starting at startFrom index. </param>
        /// <returns> The string between startString and endString, starting at startFrom. </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert Cyrillic letters to their latin letters representation.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <returns> A new string with the converted letters. </returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convert Latin letters to their Cyrillic letters representation.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <returns> A new string with the converted letters. </returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts string to latin letters and replaces forbidden characters.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <returns> The evaluated string. </returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            var validUsername = Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
            return validUsername;
        }

        /// <summary>
        /// Converts string to latin letters and replaces forbidden characters.
        /// </summary>
        /// <param name="input"> String to evaluate. </param>
        /// <returns> The evaluated string. </returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            var validLatinFileName = Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
            return validLatinFileName;
        }

        /// <summary>
        /// Extract the frist charsCount characters.
        /// </summary>
        /// <param name="input"> String to perform the operation on. </param>
        /// <param name="charsCount"> Number of characters to extract. </param>
        /// <returns> The first charsCount characters as a new string. </returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            var firstCharacters = input.Substring(0, Math.Min(input.Length, charsCount));
            return firstCharacters;
        }

        /// <summary>
        /// Extract the file extension.
        /// </summary>
        /// <param name="fileName"> String representing a file path. </param>
        /// <returns> The file extension. </returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            var fileExtension = fileParts.Last().Trim().ToLower();
            return fileExtension;
        }

        /// <summary>
        /// Match a file extension to content type.
        /// </summary>
        /// <param name="fileExtension"> File extension to evaluate. </param>
        /// <returns> The content type matched to the file extension. </returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };

            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            var dafaultValue = "application/octet-stream";
            return dafaultValue;
        }

        /// <summary>
        /// Convert a string to a byte[].
        /// </summary>
        /// <param name="input"> String to convert. </param>
        /// <returns> A byte[] with the string content. </returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
