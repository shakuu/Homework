using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation2
{
    public class Documentation2
    {
        private const int Mask = 32;
        private const int AlphabetLength = 26;

        //private static Dictionary<int, int> alphabetIndexes;

        public static void Main()
        {
            //alphabetIndexes = new Dictionary<int, int>();
            //for (int charCode = 'a'; charCode <= 'z'; charCode++)
            //{
            //    alphabetIndexes.Add(charCode, charCode - 'a');
            //}

            var inputString = Console.ReadLine().ToCharArray();
            var inputLength = inputString.Length;

            var cost = 0;
            var leftCrawlIndex = 0;
            var rightCrawlIndex = inputLength - 1;
            while (leftCrawlIndex < inputLength && rightCrawlIndex >= 0)
            {
                char leftChar = inputString[leftCrawlIndex];
                while (!char.IsLetter(leftChar) && leftCrawlIndex < inputLength)
                {
                    leftCrawlIndex++;
                    if (leftCrawlIndex >= rightCrawlIndex)
                    {
                        break;
                    }

                    leftChar = inputString[leftCrawlIndex];
                }

                char rightChar = inputString[rightCrawlIndex];
                while (!char.IsLetter(rightChar) && leftCrawlIndex >= 0)
                {
                    rightCrawlIndex--;
                    if (leftCrawlIndex >= rightCrawlIndex)
                    {
                        break;
                    }

                    rightChar = inputString[rightCrawlIndex];
                }

                if (leftCrawlIndex >= rightCrawlIndex)
                {
                    break;
                }

                cost += GetCostNoDictionary(leftChar, rightChar);

                leftCrawlIndex++;
                rightCrawlIndex--;
            }

            Console.WriteLine(cost);
        }

        private static int GetCostNoDictionary(char a, char b)
        {
            var lowerA = a | Documentation2.Mask;
            var lowerB = b | Documentation2.Mask;

            var difference = Math.Abs(lowerA - lowerB);
            var difference2 = Documentation2.AlphabetLength - difference;

            return difference >= difference2 ? difference2 : difference;
        }

        //private static int GetCost(char a, char b)
        //{
        //    var lowerA = a | Mask;
        //    var lowerB = b | Mask;

        //    var indexA = alphabetIndexes[lowerA];
        //    var indexB = alphabetIndexes[lowerB];

        //    if (indexA == indexB)
        //    {
        //        return 0;
        //    }
        //    else if (indexA < indexB)
        //    {
        //        var optionA = indexB - indexA;
        //        var optionB = indexA + AlphabetLength - indexB;

        //        return optionA >= optionB ? optionB : optionA;
        //    }
        //    else
        //    {
        //        var optionA = indexA - indexB;
        //        var optionB = indexB + AlphabetLength - indexA;

        //        return optionA >= optionB ? optionB : optionA;
        //    }
        //}
    }
}
