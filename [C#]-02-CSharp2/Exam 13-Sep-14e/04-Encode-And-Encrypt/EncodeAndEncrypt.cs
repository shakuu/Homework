
namespace _04_Encode_And_Encrypt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class EncodeAndEncrypt
    {
        // By description
        static char addChrA = 'A';

        static StringBuilder text;
        static StringBuilder cypher;
        static StringBuilder temp;
        static StringBuilder output;

        static void EncryptWithTextLongerThanCypher(StringBuilder shorter, 
                            StringBuilder longer)
        {
            temp = new StringBuilder();

            var shorterLength = shorter.Length;

            for (int sym = 0; sym < longer.Length; sym++)
            {
                var shorterSym = sym % shorterLength;

                var symShorter = (shorter[shorterSym] - addChrA);
                var symLonger = (longer[sym] - addChrA);

                var newSymbol = (symLonger ^ symShorter) + addChrA;

                temp.Append((char)newSymbol);
            }
        }

        static void EncryptWithCypherLongerThanText(StringBuilder shorter,
                             StringBuilder longer)
        {
            temp = new StringBuilder();

            for (int sym = 0; sym < shorter.Length; sym++)
            {
                var symShorter = (shorter[sym] - addChrA);
                var symLonger = (longer[sym] - addChrA);

                var newSymbol = (symLonger ^ symShorter) + addChrA;

                temp.Append((char)newSymbol);
            }

            var tempLength = temp.Length;

            for (int sym = shorter.Length; sym < longer.Length; sym++)
            {
                var tempSym = sym % tempLength;

                var symShorter = (temp[tempSym] - addChrA);
                var symLonger = (longer[sym] - addChrA);

                var newSymbol = (symLonger ^ symShorter) + addChrA;

                temp.Insert(tempSym, (char)newSymbol);
                temp.Remove(tempSym + 1, 1);
            }
        }

        static void Encode()
        {
            var cypherLenght = cypher.Length;

            // Add the cypher for encoding
            temp.Append(cypher);

            output = new StringBuilder();

            var counter = 1;
            var prevSym = temp[0];

            for (int sym = 1; sym < temp.Length; sym++)
            {
                if (temp[sym] == prevSym) counter++;
                else
                {
                    AppendSymbols(counter, prevSym);

                    prevSym = temp[sym];
                    counter = 1;
                }
            }

            // Flush the remaining symbol
            AppendSymbols(counter, prevSym);

            // Add counter
            output.Append(cypherLenght);
        }

        static void AppendSymbols(int counter, char prevSym)
        {
            if (counter > 2)
            {
                output.Append(counter);
                output.Append(prevSym);
            }
            else if (counter == 2)
            {
                output.Append(prevSym);
                output.Append(prevSym);
            }
            else
            {
                output.Append(prevSym);
            }
        }

        static void Input()
        {
            text = new StringBuilder( Console.ReadLine());
            cypher = new StringBuilder(Console.ReadLine());
        }

        static void Main()
        {
            Input();

            if (text.Length < cypher.Length)
                 EncryptWithCypherLongerThanText(text, cypher);
            else EncryptWithTextLongerThanCypher(cypher, text);

            Encode();

            Console.WriteLine(output);
        }
    }
}
