using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBit1
{
    class FormulaBit1
    {
        class Car
        {
            public int vSpeed = 0;
            public int hSpeed = 0;
            public int currRow = 0;
            public int currCol = 0;
            public int stepsCount = 1;
            public bool changeDirection = false;
            public bool isSuccessful = false;
            public List<string> directionLog = new List<string>();
            public List<int> stepsBetweenDirectionChange = new List<int>();

            public Car(int vPos, int hPos, int vSpd, int hSpd)
            {
                this.currRow = vPos;
                this.currCol = hPos;
                this.vSpeed = vSpd;
                this.hSpeed = hSpd;
            }

            public Car(int vPos, int hPos)
            {
                this.currRow = vPos;
                this.currCol = hPos;
            }
        }

        static void Main()
        {
            //build the track
            string[] bitTrack = new string[8];
            for (int row = 0; row < bitTrack.Length; row++)
            {
                bitTrack[row] = Convert.ToString(
                    int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
            }
            //start by moving South
            //@top right corner of the trach
            Car car5 = new Car(0, bitTrack.Length - 1); // seb vettel ftw
            car5.vSpeed = 1;
            car5.directionLog.Add("south");
            car5.stepsBetweenDirectionChange.Add(0);
            //check if starting position is 0
            if (bitTrack[car5.currRow][car5.currCol] != '0')
            {
                Console.WriteLine("No {0}", car5.stepsCount);
            }
            //get moving
            while (true)
            {
               
                //check if next position out of bounds
                if (car5.currRow + car5.vSpeed < 0 ||
                      car5.currRow + car5.vSpeed > bitTrack.Length - 1 ||
                      car5.currCol + car5.hSpeed < 0 ||
                      car5.currCol + car5.hSpeed > bitTrack.Length - 1)
                {
                    car5.changeDirection = true;
                }
                //check if the next step in the current direction is free ( == 0 )
                else if (bitTrack[car5.currRow + car5.vSpeed][
                    car5.currCol + car5.hSpeed] == '0')
                {
                    car5.currRow += car5.vSpeed;
                    car5.currCol += car5.hSpeed;
                    car5.stepsCount++;
                    car5.changeDirection = false;
                }
                else
                {
                    car5.changeDirection = true;
                }

                if (car5.changeDirection == true) //change direction of travel
                {
                    //if new direction is not viable -> game over
                    if (car5.stepsCount == car5.stepsBetweenDirectionChange[
                        car5.stepsBetweenDirectionChange.Count - 1])
                    {
                        car5.isSuccessful = false;
                        break;
                    }
                    //change direction
                    switch (car5.directionLog[car5.directionLog.Count - 1])
                    {
                        case "south": //switch to west
                            car5.vSpeed = 0;
                            car5.hSpeed = -1;
                            car5.directionLog.Add("west");
                            car5.stepsBetweenDirectionChange.Add(car5.stepsCount);
                            break;
                        case "north": //switch to west
                            car5.vSpeed = 0;
                            car5.hSpeed = -1;
                            car5.directionLog.Add("west");
                            car5.stepsBetweenDirectionChange.Add(car5.stepsCount);
                            break;
                        case "west": //switch check previous direction
                            if (car5.directionLog[car5.directionLog.Count - 2]
                                == "south") //if south switch to north
                            {
                                car5.vSpeed = -1;
                                car5.hSpeed = 0;
                                car5.directionLog.Add("north");
                                car5.stepsBetweenDirectionChange.Add(car5.stepsCount);
                            }
                            else //else switch to south
                            {
                                car5.vSpeed = 1;
                                car5.hSpeed = 0;
                                car5.directionLog.Add("south");
                                car5.stepsBetweenDirectionChange.Add(car5.stepsCount);
                            }
                            break;
                    }
                   
                    //if current position is exit = win 
                    if (car5.currRow == 7 && car5.currCol == 0)
                    {
                        car5.isSuccessful = true;
                        break;
                    }
                }
            }
            if (car5.isSuccessful)
            {
                Console.WriteLine("{0} {1}",
                    car5.stepsCount, car5.directionLog.Count - 1);
            }
            else
            {
                Console.WriteLine("No {0}", car5.stepsCount);
            }
        }
    }
}
