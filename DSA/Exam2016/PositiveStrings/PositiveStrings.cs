using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositiveStrings
{
    public class PositiveStrings
    {
        public static void Main()
        {
            var template = Console.ReadLine();

            var previousNumberString = new StringBuilder();
            var nextNumberString = new StringBuilder();

            var isAfterTemplate = false;
            var isBeforeTemplate = true;
            var isSeparator = false;
            var isTemplate = false;

            var previousNumber = -1;
            var nextNumber = -1;

            var currentTemplate = new StringBuilder();

            var templateLength = template.Length;
            for (int index = 0; index < templateLength; index++)
            {
                var nextChar = template[index];

                if (nextChar == '?')
                {
                    isTemplate = true;

                    if (isSeparator)
                    {
                        previousNumber = int.Parse(previousNumberString.ToString());

                        isBeforeTemplate = false;
                        isTemplate = true;

                        isSeparator = false;
                    }

                    currentTemplate.Append('?');
                }
                else if (nextChar == ',')
                {
                    if (isTemplate)
                    {
                        isTemplate = false;
                        isAfterTemplate = true;
                    }
                    else if (isAfterTemplate)
                    {
                        isAfterTemplate = false;
                        isBeforeTemplate = true;
                    }

                    isSeparator = true;
                }
                else if (char.IsDigit(nextChar))
                {
                    if (isBeforeTemplate)
                    {
                        if (isSeparator)
                        {
                            previousNumberString.Clear();
                            isSeparator = false;
                        }

                        previousNumberString.Append(nextChar);
                    }
                    else if (isAfterTemplate)
                    {
                        if (isSeparator)
                        {
                            nextNumberString.Clear();
                            isSeparator = false;
                        }

                        nextNumberString.Append(nextChar);
                    }
                }
            }
        }
    }
}
