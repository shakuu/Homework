using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronsMap
{
    class NeuronsMap
    {
        class Neurons
        {
            public char Value;
            public bool isNeuron = false;

            public Neurons(char cVal)
            {
                this.Value = cVal;
            }

            public Neurons(string cStr, int cPos)
            {
                this.Value = cStr[cPos];
            }
        }

        static void Main()
        {
            //given
            const int stringLength = 32;
            //Input : N numbers , while NOT negative
            List<string> inputStrings = new List<string>();
            long toAdd;
            while (true)
            {
                toAdd = long.Parse(Console.ReadLine());
                if (toAdd < 0) { break; }

                inputStrings.Add(Convert.ToString(toAdd, 2).PadLeft(stringLength, '0'));
            }
            //Create Neurons Grid
            Neurons[,] neuronGrid
                = new Neurons[inputStrings.Count, stringLength];
            //check each bit
            for (int currRow = 0;
                currRow<inputStrings.Count; currRow++)
            {
                for (int currCol = 0; currCol<stringLength; currCol++)
                {
                    bool boundRight = false;
                    bool boundTop = false;
                    bool boundBot = false;
                }
            }
        }
    }
}
