using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositiveStrings2
{
    public class Strings2
    {
        private static string[] characters = ",0123456789".Split();

        public static void Main()
        {
            var inputStringSections = Console.ReadLine().Split(',').ToList();

            for (int sectionIndex = 0; sectionIndex < inputStringSections.Count; sectionIndex++)
            {
                var nextSection = inputStringSections[sectionIndex];

                if (nextSection[0] == '0')
                {
                    Console.WriteLine("Invalid");
                    break;
                }

                if (nextSection.IndexOf("?") >= 0)
                {
                    var previous = sectionIndex > 0 ? inputStringSections[sectionIndex - 1] : null;
                    var next = sectionIndex + 1 < inputStringSections.Count ? inputStringSections[sectionIndex + 1] : null;

                    Strings2.ReplaceQuestionMarks(nextSection, previous, next);
                }
            }
        }

        private static void ReplaceQuestionMarks(string section, string previous, string next)
        {
            var previousValue = -1;
            if (previous != null)
            {
                previousValue = int.Parse(previous);
            }

            var nextValue = -1;
            if (next != null)
            {
                nextValue = int.Parse(next);
            }

            var nextPossibleValue = string.Empty;
            var nextMarkIndex = section.IndexOf("?");
            while (nextMarkIndex >= 0)
            {
                if (nextMarkIndex == section.Length - 1 && (previousValue + 1).ToString().Length > 1)
                {
                    nextPossibleValue += "0";
                    previousValue = int.Parse(nextPossibleValue);

                    nextPossibleValue = "0";
                }
                else if (nextMarkIndex == 0 && previousValue < 0)
                {
                    nextPossibleValue = "1";
                    previousValue = 1;
                }
                else if (nextMarkIndex != 0 && nextPossibleValue != ",")
                {
                    if (nextMarkIndex != section.Length - 1)
                    {
                        nextPossibleValue = ",";
                    }
                    else
                    {
                        nextPossibleValue = "0";
                    }
                }
                else if (previousValue >= 0)
                {
                    nextPossibleValue = (previousValue + 1).ToString();
                    previousValue++;
                }

                section = section.Remove(nextMarkIndex, nextPossibleValue.Length);
                section = section.Insert(nextMarkIndex, nextPossibleValue);

                if (nextMarkIndex + nextPossibleValue.Length >= section.Length)
                {
                    break;
                }
                else
                {
                    nextMarkIndex = section.IndexOf("?", nextMarkIndex + nextPossibleValue.Length);
                }
            }

            Console.WriteLine($"{section}, {previous}, {next}");
        }
    }
}
