using System;
using System.Collections.Generic;

namespace _14_Word_Dictionary
{
    class WordDictionary
    {
        static void Main()
        {
            var NewDictionary = new Dictionary<string, string>()
            {
                { ".NET", "platform for applications from Microsoft" },
                { "CLR", "managed execution environment for .NET" },
                { "namespace", "hierarchical organization of classes" }
            };

            var input = Console.ReadLine();

            Console.WriteLine(NewDictionary[input]);
        }
    }
}
