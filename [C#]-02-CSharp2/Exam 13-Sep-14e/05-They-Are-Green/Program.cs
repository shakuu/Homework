
namespace _05_They_Are_Green
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static int stringSize;
        static List<int> elements;
        static int output;

        static void Input()
        {
            stringSize = int.Parse(Console.ReadLine());

            var readNumbers = Enumerable.Range(0, stringSize)
                .Select(x => Console.ReadLine()).ToArray();

            elements = readNumbers
                .GroupBy(x => x)
                .Select(x => x.Count())
                .ToList();
        }

        static void GetCombinations()
        {
            // Case no combinations available
            if (stringSize < elements[0] + elements[0] - 1)
            {
                output = 0;
                return;
            }
            
            // Case there is an element which needs to be 
            // on position 0 and has only one possible way 
            // to distribute accross the string
            if (stringSize == elements[0] + elements[0] - 1)
                GetCombinationsWithFixedElement();

            output = 1;

            while (elements.Count() > 0)
            {
                for (int element = elements.Count - 1; element >= 0; element--)
                {
                    // not counting from zero
                    output *= element + 1;
                    elements[element]--;

                    if (elements[element] < 1)
                    {
                        elements.RemoveAt(element);
                    }
                }
            }

        }

        static void GetCombinationsWithFixedElement()
        {
            // Remove the Element 
            stringSize -= elements[0];
            elements.RemoveAt(0);

            // Every position is guaranteed to be 
            // separated by 1 other letter
            output = 1;

            for (int i = 1; i < stringSize; i++)
            {
                output *= Math.Min(i, elements.Count());
            }
        }

        static void Main()
        {
            Input();
            GetCombinations();
            Console.WriteLine(output);
        }
    }
}
