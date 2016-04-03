using System;
using System.Linq;


namespace TextToNumber
{
    class TextToNumber
    {
        static void Main()
        {
            int Module = int.Parse(Console.ReadLine());
            string TextToParse = Console.ReadLine();

            string alphabet = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            string[] letters = alphabet.Split(' ');
            alphabet = null;

            int RESULT = 0;
            int currIndex = 0;

            bool isUpdate = false;

            while (true)
            {
                // check @
                if (TextToParse.ElementAt(currIndex).ToString() == "@")
                {
                    Console.WriteLine(RESULT);
                    return;
                }
                //check Number
                for (int i = 0; i < 10; i++)
                {
                    if (TextToParse.ElementAt(currIndex).ToString() == i.ToString())
                    {
                        RESULT *= i;
                        isUpdate = true;
                    }
                }
                //check letter
                for (int i = 0; i < letters.Length; i++)
                {
                    if (TextToParse.ElementAt(currIndex).ToString().ToUpper() == letters[i].ToUpper())
                    {
                        RESULT += i;
                        isUpdate = true;
                    }
                }

                if (isUpdate != true)
                {
                    RESULT = RESULT % Module;
                }

                isUpdate = false;
                currIndex++;
            }

        }
    }
}
