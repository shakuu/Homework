using System;
using System.Collections.Generic;

namespace ColorfulBunnies
{
    public class ColorfulBunnies
    {
        public static void Main()
        {
            var answersDictionary = new Dictionary<long, long>();

            var inputCount = long.Parse(Console.ReadLine());
            for (long i = 0; i < inputCount; i++)
            {
                var nextValue = long.Parse(Console.ReadLine());
                if (answersDictionary.ContainsKey(nextValue))
                {
                    answersDictionary[nextValue]++;
                }
                else
                {
                    answersDictionary.Add(nextValue, 1);
                }
            }

            long bunnies = 0;
            foreach (var pair in answersDictionary)
            {
                var key = pair.Key;
                var value = pair.Value;

                if (value <= key + 1)
                {
                    bunnies += key + 1;
                }
                else
                {
                    var mathcingBunniesCount = Math.Ceiling((double)value / (double)(key + 1));
                    var bunniesToAdd = (long)(mathcingBunniesCount * (key + 1));
                    bunnies += bunniesToAdd;
                }
            }

            Console.WriteLine(bunnies);
        }
    }
}
