using System;
using System.Linq;


namespace TextToNumbers2
{
    class TextToNum2
    {
        static void Main()
        {
            short Module = short.Parse(Console.ReadLine());
            string TextToParse = Console.ReadLine().ToUpper();
            int currIndex = 0;
            long RESULT = 0;
            while(true)
            {
                if (TextToParse.ElementAt(currIndex).ToString() == "@")
                {
                    Console.WriteLine(RESULT);
                    Environment.Exit(0);
                }
                else if (TextToParse.ElementAt(currIndex) > 47 && //number
                    TextToParse.ElementAt(currIndex) < 58)
                {
                    RESULT *= (TextToParse.ElementAt(currIndex) - 48);
                    goto nexti;
                }
                else if (TextToParse.ElementAt(currIndex) > 64 && // letter
                    TextToParse.ElementAt(currIndex) < 91)
                {
                    RESULT += (TextToParse.ElementAt(currIndex) - 65);
                    goto nexti;
                }
                //else if (TextToParse.ElementAt(currIndex) > 96 && // letter
                //    TextToParse.ElementAt(currIndex) < 123)
                //{
                //    RESULT += (TextToParse.ElementAt(currIndex) - 97);
                //    goto nexti;
                //}
                else
                {
                    RESULT = RESULT % Module;
                }
            nexti:; 
                currIndex++;
            }
        }
    }
}
