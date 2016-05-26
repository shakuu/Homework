
namespace _04_Konspiration_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Konspiration2
    {
        // Store found methods
        static List<string> foundMethods = new List<string>();
        static List<List<string>> invokedMethods = new List<List<string>>();
        static string curMethod;

        static void ParseLine(string[] line)
        {
            var isNewObject = false;
            var isNewMethod = false;
            var isMethod = false;

            var methodName = new StringBuilder();

            for (int index = 0; index < line.Length; index++)
            {
                if (line[index] == "static")
                {
                    // new method declaration
                    isNewMethod = true;
                }

                else if (line[index] == "new")
                {
                    // next is an object declaration
                    isNewObject = true;
                }

                else
                {
                    // look for methods/ object.Methods
                    for (int ltrIndex = 0; ltrIndex < line[index].Length; ltrIndex++)
                    {
                        var letter = line[index][ltrIndex];

                        var zeroIndex = ltrIndex == 0 ?
                            true : !char.IsLetter(line[index][ltrIndex - 1]);

                        if (char.IsUpper(letter) && zeroIndex)
                        {
                            isMethod = true;
                            methodName.Append(letter);
                        }
                        else if (letter == '.')
                        {
                            // object.method
                            methodName.Clear();
                        }
                        else if(!char.IsLetter(letter) &&
                                letter != '(')    //else if (letter == '<')
                        {
                            // List<>, Dictionary<> etc
                            isMethod = false;
                            methodName.Clear();
                        }
                        else if (letter == '(')
                        {
                            var newMethod = methodName.ToString();

                            if (!string.IsNullOrEmpty(newMethod))
                            {
                                if (isNewMethod)
                                {
                                    isNewMethod = false;

                                    // Add the name to found and create its list
                                    // of invoked methods
                                    foundMethods.Add(newMethod);
                                    invokedMethods.Add(new List<string>());

                                    // Set current method as this one
                                    curMethod = newMethod;
                                }

                                else if (isNewObject)
                                {
                                    // Do nothing
                                    isNewObject = false;
                                }
                                else
                                {
                                    // Index of the current method
                                    var indexListToAddTo =
                                        foundMethods.IndexOf(curMethod);

                                    invokedMethods[indexListToAddTo].Add(newMethod);
                                }
                            }

                            methodName.Clear();
                            isMethod = false;
                        }
                        else if (isMethod)
                        {
                            methodName.Append(letter);
                        }
                    }
                }
            }
        }

        static void Output()
        {
            for (int index = 0; index < foundMethods.Count(); index++)
            {
                if (invokedMethods[index].Count() > 0)
                {
                    Console.WriteLine("{0} -> {1} -> {2}",
                        foundMethods[index],
                        invokedMethods[index].Count(),
                        string.Join(", ", invokedMethods[index]));
                }
                else
                {
                    Console.WriteLine("{0} -> None", foundMethods[index]);
                }
            }
        }

        static void Main()
        {
            var linesOfInput = int.Parse(Console.ReadLine());
            var lineNumber = 0;

            while (lineNumber < linesOfInput)
            {
                var line = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ++lineNumber;

                ParseLine(line);
            }

            Output();
        }
    }
}
