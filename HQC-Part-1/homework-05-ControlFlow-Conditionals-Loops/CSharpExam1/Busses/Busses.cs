using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busses
{
    class Busses
    {
        static void Main()
        {

            //input 
            int NumOfBusses = int.Parse(Console.ReadLine());

            //variables
            int currSpeed = 0;
            int prevSpeed = 0;

            // Busses - contains speeds
            List<int> Busses = new List<int>();

            int GroupsCounter = 1;

            //first bus
            prevSpeed = int.Parse(Console.ReadLine());

            //second bus
            for (int Bus = 1; Bus < NumOfBusses; Bus++)
            {
                // Step 1: read current speed
                currSpeed = int.Parse(Console.ReadLine());
                
                //Step 2: Compare to previous
                if (currSpeed > prevSpeed)
                {
                    currSpeed = prevSpeed;
                }
                else
                {
                    GroupsCounter++;

                    prevSpeed = currSpeed;
                }
            }
            //output
            Console.WriteLine(GroupsCounter);
        }
    }
}
