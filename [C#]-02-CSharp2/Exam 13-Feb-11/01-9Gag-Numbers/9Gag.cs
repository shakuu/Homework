
namespace _01_9Gag_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    class _9Gag_Numbers
    {
        private static StringBuilder input;
        private static BigInteger result;
        private static Dictionary<string, int> nineGag;
        
        static void BuildDictionary()
        {
            nineGag = new Dictionary<string, int>()
            {
                { "-!"    , 0 },
                { "**"    , 1 },
                { "!!!"   , 2 },
                { "&&"    , 3 },
                { "&-"    , 4 },
                { "!-"    , 5 },
                { "*!!!"  , 6 },
                { "&*!"   , 7 },
                { "!!**!-", 8 },
            };
        }
        static void Input()
        {
            input = new StringBuilder( Console.ReadLine());
        }

        static void ConvertToDecimalNumber()
        {
            var gagBase = nineGag.Count;
            var curDigit = new StringBuilder();
            result = (BigInteger)0;

            for (int ltr = 0; ltr < input.Length; ltr++)
            {
                curDigit.Append(input[ltr]);

                if (nineGag.ContainsKey(curDigit.ToString()))
                {
                    result =
                        nineGag[curDigit.ToString()] 
                        + result 
                        * gagBase;

                    curDigit.Clear();
                }
            }
        }
        static void Main()
        {
            Input();
            BuildDictionary();
            ConvertToDecimalNumber();
            Console.WriteLine(result);
        }
    }
}
