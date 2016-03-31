using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoscelesTrialngle
{
    class IsoscelesTriangle
    {
        static void Main(string[] args)
        {
            //Set console encoding to UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.SetWindowPosition(0, 0);
            Console.Title = "ISOSCELES TRIANGLE";

            //Variables
            byte triHeight = 10; //Number of Rows
            byte triWidth = 7; //Number of Columns
            byte maxHeight = 103;
            byte maxWidth = 103;
            //Promtp For Dimensions 
            bool withinRange = false;
            do //ASK FOR HEIGHT
            {   try
                {   Console.WriteLine("Enter Triangle Hight: ( 4 - {0} )", maxHeight);
                    triHeight = Convert.ToByte(Console.ReadLine());
                    if (triHeight < 4 || triHeight > maxHeight) //check within range
                    { throw new System.ArgumentOutOfRangeException(); }
                    withinRange = true; // EXIT DO LOOP
                }
                catch (System.OverflowException e)
                {   withinRange = false;
                    Console.Clear();
                    Console.WriteLine(e.Message + "\nPlease follow the instructions.");
                }
                catch(System.ArgumentOutOfRangeException e)
                {   withinRange = false;
                    Console.Clear();
                    Console.WriteLine(e.Message + "\nPlease follow the instructions.");
                }
                finally { } //do nothing
            } while (withinRange == false);
            withinRange = false; // reset within range
            Console.Clear();
            do //ASK FOR WIDTH
            {   try
                {
                    Console.WriteLine("Triangle Height set: {0}\nEnter Triangle Width: ( 7 - {1} )", 
                        triHeight, maxWidth);
                    triWidth = Convert.ToByte(Console.ReadLine());
                    if (triWidth < 7 || triHeight > maxWidth) // within range
                    { throw new System.ArgumentOutOfRangeException(); }
                    withinRange = true; // EXIT DO LOOP
                }
                catch (System.OverflowException e)
                {
                    withinRange = false;
                    Console.Clear();
                    Console.WriteLine(e.Message + "\nPlease follow the instructions.");
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    withinRange = false;
                    Console.Clear();
                    Console.WriteLine(e.Message + "\nPlease follow the instructions.");
                }
                finally { } // do nothing 
            } while (withinRange == false);
            //Convenient Values
            // Height (Rows - 4)/3 = 0
            while ((triHeight - 4) % 3 != 0)
            {   if(triHeight<maxHeight)
                { triHeight++; }
                else
                { triHeight--; }
            } 
            //Width (Cols - 4)/3 = 0 AND Odd 
            while ((triWidth-4) % 3 !=0)
            {   if (triWidth < maxWidth)
                { triWidth++; }
                else
                { triWidth--; }
            }
            if(triWidth%2==0) //check odd
            {   if( triWidth>7) { triWidth = (byte) (triWidth - 3); }
                else { triWidth = (byte) (triWidth + 3); }
            }
            //check Hieht != Width
            if (triHeight==triWidth)
            {   if(triHeight==4) { triHeight = (byte)(triHeight + 3); }
               else if (triHeight==maxHeight) { triHeight = (byte)(triHeight - 3); } 
               else { triHeight = (byte)(triHeight + 3); }
            }
            //Print
            PrintTriangle(triHeight, triWidth);
        }   //END MAIN
   
        //Print Triangle 
        static void PrintTriangle(byte Height, byte Width)
        {
            Console.Clear();
            int verticalOffset = 0; //Offset from center column 

            for (byte rowIndex = 0; rowIndex < Height; rowIndex++) //for each row
            {
                if (rowIndex == 0 || //ROW1
                    rowIndex == 0 + ((Height - 4) / 3 + 1) || //ROW2
                    rowIndex == 0 + (((Height - 4) / 3 + 1)) * 2) // ROW3
                {
                    for (byte colIndex = 0; colIndex < Width; colIndex++) //for each column
                    {
                        if (colIndex == (Width - 1) / 2 - verticalOffset
                              || colIndex == (Width - 1) / 2 + verticalOffset)
                        { Console.Write("\u00A9"); }
                        else
                        { Console.Write("."); };
                    }//end FOR
                    //New Row, Add ofset
                    Console.Write("\n");
                    verticalOffset += ((Width - 4) / 3 + 1) / 2;
                } //end IF
                else if (rowIndex == Height - 1) //Print Last row
                {
                    for (byte colIndex = 0; colIndex < Width; colIndex++)
                    {
                        if (colIndex == 0 ||  //Position 1
                                              //Position 2                                  
                              colIndex == 0 + ((Width - 4) / 3 + 1) ||
                              //Position 3
                              colIndex == 0 + (((Width - 4) / 3 + 1)) * 2 ||
                              //Position 4
                              colIndex == Width - 1)
                        //Print Special Symbol
                        { Console.Write("\u00A9"); } //END IF
                        //Print Empty Space
                        else { Console.Write("."); } //END ELSE
                    } //END FOR
                }//end ELSE IF
                else //print empty rows
                {
                    for (byte colIndex = 0; colIndex < Width; colIndex++)
                    { Console.Write("."); } //END FOR
                    //Print New Line
                    Console.Write("\n");
                }   //END ELSE
            }

            Console.WriteLine("\n\nOoh Rah!");
        }   //End Function

    }
}
