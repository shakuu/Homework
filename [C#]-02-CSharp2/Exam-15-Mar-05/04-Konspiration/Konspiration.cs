
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
                // a name of a previously declared method
                foreach (var existing in foundMethods)
                {
                    if (item.Contains(existing))
                    {
                        // 1. Confirm the string is a name
                        // 2. Set current method
                    }
                }
            }
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

            var toAddName = newMethodName.ToString().Trim();
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

                // Search for 
                // 1. Declaring methdos
                // 2. Invoking methods
                ParseLine(curLine);

            }
        }
    }
}
