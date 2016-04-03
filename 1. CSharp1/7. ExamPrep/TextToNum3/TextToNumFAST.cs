using System;


class TextToNum3
{
    static void Main()
    {
        short Module = short.Parse(Console.ReadLine());
        string TextToParse = Console.ReadLine().ToUpper();
        char[] text = TextToParse.ToCharArray();
        int currIndex = 0;
        long RESULT = 0;
        while (true)
        {
            if (text[currIndex].ToString() == "@")
            {
                Console.WriteLine(RESULT);
                Environment.Exit(0);
            }
            else if (text[currIndex] > 64 && // letter
                text[currIndex] < 91)
            {
                RESULT += (text[currIndex] - 65);
                goto nexti;
            }
            else if (text[currIndex] > 47 && //number
                text[currIndex] < 58)
            {
                RESULT *= (text[currIndex] - 48);
                goto nexti;
            }
            //else if (text[currIndex] > 64 && // letter
            //    text[currIndex] < 91)
            //{
            //    RESULT += (text[currIndex] - 65);
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

