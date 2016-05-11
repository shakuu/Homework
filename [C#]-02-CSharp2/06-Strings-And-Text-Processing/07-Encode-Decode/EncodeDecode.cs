using System;
using System.Text;

namespace _07_Encode_Decode
{
    class EncodeDecode
    {
        static void Main()
        {
            var key = Console.ReadLine();

            var toParse = Console.ReadLine();

            Console.WriteLine(Encode(toParse, key));
        }

        static string Encode(string toParse, string Key)
        {
            var encoding = new StringBuilder();

            for (int curIndex = 0;
                     curIndex < toParse.Length;
                     curIndex++)
            {
                var keyIndex = curIndex % Key.Length;

                encoding.Append(
                    (char)(toParse[curIndex] ^ Key[keyIndex])
                    );
            }

            return encoding.ToString();
        }
    }
}
