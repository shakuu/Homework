
namespace _10_Unicode_Characters_4
{
    using System;

    class UnicodeCharacters4
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var encoding = new System.Text.UTF32Encoding();

            var bytes = encoding.GetBytes(input);

            // index = start index to read from,
            // increment with the size of an int when reading int
            for (int index = 0; index < bytes.Length; index += sizeof(int))
            {
                var unicode = BitConverter.ToInt32(bytes, index);

                Console.Write(@"\u{0:X4}", unicode);
            }
        }
    }
}
