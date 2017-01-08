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
                        nextNumber = int.Parse(nextNumberString.ToString());

                        isAfterTemplate = false;
                        isBeforeTemplate = true;

                        // TODO: Replace question marks here.
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
                            previousNumber = -1;
                            isSeparator = false;
                        }

                        previousNumberString.Append(nextChar);
                        previousNumber = int.Parse(previousNumberString.ToString());
                    }
                    else if (isAfterTemplate)
                    {
                        if (isSeparator)
                        {
                            nextNumberString.Clear();
                            nextNumber = -1;
                            isSeparator = false;
                        }

                        nextNumberString.Append(nextChar);
                        nextNumber = int.Parse(nextNumberString.ToString());
                    }
                }
            }

            if (isTemplate)
            {
                // TODO: Replace question marks here. ( in case the entire template is only question marks )
            }
        }
    }
}
