using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuronsSimple
{
    class NeuronsSimple
    {
        static void Main()
        {
            //get strings 
            List<string> inStrings = new List<string>();
            long toAdd;
            while (true)
            {
                toAdd = long.Parse(Console.ReadLine());
                if (toAdd < 0) { break; }

                inStrings.Add(Convert.ToString(toAdd, 2).PadLeft(32, '0'));
            }

            for (int currIndex = 0; currIndex < inStrings.Count; currIndex++)
            {
                //if current string contains 1 -> replace 1s with 0s and 0s with 1s
                if (inStrings[currIndex].Contains('1'))
                {
                    int currPos = inStrings[currIndex].IndexOf('1');
                    string currNeuron = inStrings[currIndex].Substring(
                        inStrings[currIndex].IndexOf('1'),
                        inStrings[currIndex].LastIndexOf('1') -
                        inStrings[currIndex].IndexOf('1') + 1);
                    currNeuron = currNeuron.Replace('0', '+');
                    currNeuron = currNeuron.Replace('1', '0');
                    currNeuron = currNeuron.Replace('+', '1');

                    inStrings[currIndex] = inStrings[currIndex].Insert(
                        currPos, currNeuron);
                    inStrings[currIndex] = inStrings[currIndex].Remove(
                        currPos + currNeuron.Length, currNeuron.Length);
                }
                //print string
                Console.WriteLine(Convert.ToInt64(inStrings[currIndex], 2));
            }
        }
    }
}
