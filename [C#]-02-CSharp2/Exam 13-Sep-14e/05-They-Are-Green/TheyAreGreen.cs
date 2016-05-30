
namespace _05_They_Are_Green
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class TheyAreGreen
    {
        // 28 / 100

        static int stringSize;
        static List<int> elements;
        static int assignedElements = 0;
        static int output = 0;
        static List<string> permutations = new List<string>();
        static List<char> inputElements = new List<char>();
        static List<string> win = new List<string>();

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

        static void Input2()
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                inputElements.Add(Console.ReadLine()[0]);
            }
        }

        static void CheckPermuatations()
        {
            output = 0;

            foreach (var str in permutations)
            {
                var isWin = true;

                if (str.Length == inputElements.Count)
                {
                    for (int i = 1; i < str.Length; i++)
                    {
                        if (str[i] == str[i - 1])
                        {
                            isWin = false;
                            break;
                            
                        }
                    }

                    if (isWin && !win.Contains(str) )
                    {
                        win.Add(str);
                        output++;
                    }
                }
            }
        }

        static void BuildTableForElement(int index)
        {
            var curElemnt = elements[index];

            var table = new int[curElemnt][];
            var counter = 1;

            var minLength = curElemnt + curElemnt - 1;

            for (int row = 0; row < curElemnt; row++)
            {
                table[row] = new int[stringSize];

                for (int col = (2 * row); col <= stringSize - minLength; col++)
                {
                    table[row][col] = 1;
                }

                minLength -= 2;
                minLength = minLength < 1 ?
                            1 : minLength;
            }

            for (int row = 0; row < Math.Max(table.Length - 1, 1); row++)
            {
                var sum = 0;

                for (int col = 0; col < table[row].Length - assignedElements; col++)
                {
                    sum += table[row][col];
                }

                counter *= sum;
            }

            output *= counter;

            assignedElements += curElemnt;
        }

        static void GetCombinations2()
        {
            var lastIndex = elements.Count - 1;

            var output = new int[stringSize];

            var lastElementUsed = -1;

            for (int cur = 0; cur < output.Length; cur++)
            {
                var possibleElements = elements.Count;

                if (lastElementUsed >= 0 && lastElementUsed < elements.Count)
                {
                    possibleElements--;
                }

                if (lastElementUsed == lastIndex)
                {
                    // not a viable build
                    break;
                }

                output[cur] = possibleElements;

                // Decrement the last index 
                // Remove if zero
                --elements[lastIndex];
                lastElementUsed = lastIndex;
                if (elements[lastIndex] == 0)
                {
                    elements.RemoveAt(lastIndex);
                    --lastIndex;
                }
            }
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
            Input2();
            Permutate(inputElements, 0, inputElements.Count - 1);
            CheckPermuatations();
            Console.WriteLine(output);
        }

        // Recursive Permutation
        public static void Permutate(List<char> toSearch, int Left, int Right)
        {
            // If the current section has 3 elements
            // Permutate them 
            if (Right - Left == 1)
            {
                for (int i = 0; i <= Right - Left; i++)
                {
                    // Step 1: Add current permutation
                    permutations.Add(string.Join("", toSearch));

                    // Step 2: Switch the 2 elements
                    toSearch[Left] ^= toSearch[Right];
                    toSearch[Right] ^= toSearch[Left];
                    toSearch[Left] ^= toSearch[Right];
                }

                // Job's done
                return;
            }

            // Otherwise, shuffle the elements
            // and pass along for permutation
            for (int curPermutation = 0;
                     curPermutation <= Right - Left;
                     curPermutation++)
            {
                // Step 1: Permutate the current section
                // less one element
                Permutate(toSearch, Left + 1, Right);

                // Step 2: Rearrange Elements
                // Last Element goes first 
                // withing the current section
                toSearch.Insert(Left, toSearch[toSearch.Count - 1]);
                toSearch.RemoveAt(toSearch.Count - 1);
            }

            return;
        }
    }
}
