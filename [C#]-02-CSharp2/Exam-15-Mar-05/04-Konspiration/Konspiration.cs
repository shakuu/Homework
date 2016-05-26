
namespace _04_Konspiration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Konspiration
    {
        // Store found methods
        static string method = "static";
        static List<string> foundMethods;
        static List<List<string>> invokedMethods;
        static string curMethod;

        // Helper
        static int curLineNumber = 0;

        // Parse current line.
        static void ParseLine(string[] curLine)
        {

            foreach (var item in curLine)
            {
                // If the line contains
                // "static" then it's a new 
                // method
                if (item == method) { AddNewMethod(curLine); break; }

                // Check if the current word contains 
                // a name of a previously declared method.
                // TODO: More checks might be needed.
                for (int i = 0; i < foundMethods.Count(); i++)
                {
                    if (item.Contains(foundMethods[i]))
                    {
                        var index = foundMethods.IndexOf(curMethod);
                        invokedMethods[index].Add(foundMethods[i]);
                    }
                }
                
                // Check if object.Method()
                if (item.Contains(".") ||
                    item.Contains("("))
                {
                    SearchForMethods(curLine);
                    break;
                }
            }
        }

        // Search for invoked static method
        static void SearchForStaticMethod(string[] curLine)
        {
            var isMethod = false;
            var methodName = new StringBuilder();

            foreach (var item in curLine)
            {
                foreach (var ltr in item)
                {
                    if (char.IsUpper(item[0])) isMethod = true;
                    if (ltr == '(') isMethod = false;
                    if (isMethod) methodName.Append(ltr);
                }
            }
        }

        static void SearchForMethods(string[] curLine)
        {
            var methodName = new StringBuilder();
            var isMethod = false;

            foreach (var item in curLine)
            {
                foreach (var chr in item)
                {
                    if (chr == '.')
                    {
                        methodName.Clear();
                        isMethod = true;
                    }

                    if (char.IsUpper(chr))
                    {
                        isMethod = true;
                    }

                    if (isMethod == true) methodName.Append(chr);

                    if (chr == '=' || chr == ',')
                    {
                        isMethod = false;
                        methodName.Clear();
                    }

                    if (chr == '(' && isMethod)
                    {
                        isMethod = false;

                        var name = ExtractName(methodName.ToString());

                        if (!string.IsNullOrEmpty(name))
                        {
                            var index = foundMethods.IndexOf(curMethod);
                            invokedMethods[index].Add(name);
                        }

                        methodName.Clear();
                    }
                }
            }
        }

        static string ExtractName(string toParse)
        {
            var name = new StringBuilder();
            var write = false;

            foreach (var ltr in toParse)
            {
                if (ltr == '.') write = true;
                else if (char.IsUpper(ltr))
                {
                    name.Append(ltr);
                    write = true;
                }
                else if (ltr == '(') break;
                else if (write) name.Append(ltr);

            }

            return name.ToString().Replace(" ", string.Empty);
        }

        static void AddNewMethod(string[] curLine)
        {
            // static T methodName (

            var newMethodName = new StringBuilder();

            // Helpers.
            var isType = false;
            var isMethod = false;
            var isArray = false;

            foreach (var item in curLine)
            {
                if (string.IsNullOrEmpty(item)) continue;

                else if (item == method)
                {
                    isType = true;
                    isMethod = true;
                    continue;
                }

                // In case type is
                // array, list, whatever
                else if (item == "<" || item == "[") isArray = true;
                else if (item == ">" || item == "]") isArray = false;

                // Method return type
                else if (isType && isMethod && !isArray) isType = false;

                else if (isMethod && !isType && !isArray)
                {
                    // Read the name
                    newMethodName.Append(item);
                }

                // Stop Reading MethodName on Opening Bracket
                if (item.Contains("(")) { isMethod = false; break; }
            }

            var toAddName = newMethodName.ToString()
                .Trim()
                .Replace(" ", string.Empty);

            newMethodName.Clear();

            foreach (var chr in toAddName)
            {
                if (!char.IsLetter(chr)) break;
                else newMethodName.Append(chr);
            }

            toAddName = newMethodName.ToString();

            // Add the name to the existing names list
            foundMethods.Add(toAddName);
            // Create a list for methods invoked
            // within this method
            invokedMethods.Add(new List<string>());
            // set current method to this method
            curMethod = toAddName;
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
            foundMethods = new List<string>();
            invokedMethods = new List<List<string>>();

            var linesOfCode = int.Parse(Console.ReadLine());

            while (curLineNumber < linesOfCode)
            {
                var curLine = Console.ReadLine()
                    .Trim()
                    .Split();
                ++curLineNumber;

                // Skip Line
                if (curLine.Contains("using") ||
                    curLine.Contains("namespace") ||
                    curLine.Contains("class"))
                {
                    continue;
                }

                // Search for 
                // 1. Declaring methdos
                // 2. Invoking methods
                ParseLine(curLine);
            }

            // Print
            Output();
        }
    }
}
