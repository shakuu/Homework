using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//111  000 010
//111  010 010
//111  000 100
//cookie - crumb - broken cookie
//mid NEEDS to be 1
//total to pay 2 decimals 

namespace GameOfPage
{
    class GameOfPage
    {
        static void Main()
        {
            //declare vars
            double pricePerCookie = 1.79D; //$1.79  
            int iBoughtCookies = 0;
            string PageSays;
            int PageSaysRow;
            int PageSaysCol;
            string myReply;

            //create a cookie tray
            List<char[]> cookieTray = new List<char[]>();
            for (int i = 0; i < 16; i++)
            {
                cookieTray.Add(Console.ReadLine().ToCharArray());
            }


            while (true)
            {
                //clear vars
                myReply = "";

                //get input
                PageSays = Console.ReadLine().ToLower();
                //end if Page says paypal
                if (PageSays == "paypal")
                {
                    Console.WriteLine("{0, 0:F2}", (double)iBoughtCookies * pricePerCookie);
                    return;
                }
                PageSaysRow = int.Parse(Console.ReadLine());
                PageSaysCol = int.Parse(Console.ReadLine());
                
                //check the tray
                myReply = CheckTheTray(PageSaysRow, PageSaysCol, cookieTray);

                if (PageSays == "what is")
                {
                    if (myReply == "nothing")
                    {
                        Console.WriteLine("smile");
                    }
                    else
                    {
                        Console.WriteLine(myReply);
                    }
                }

                if (PageSays=="buy")
                {
                    if (myReply=="nothing")
                    {
                        Console.WriteLine("smile");
                    }
                    else if ( myReply == "cookie crumb" 
                        || myReply=="broken cookie")
                    {
                        Console.WriteLine("page");
                    }
                    else if ( myReply== "cookie")
                    {
                        iBoughtCookies++;
                        cookieTray = TakeACookie(PageSaysRow, PageSaysCol, cookieTray); // take the cookie out of the tray
                    }
                }
            }
        }

        public static string CheckTheTray(int currRow, int currCol, List<char[]> theTray)
        {
            string currReply = "";
            int crumbCounter = 0;

            for ( int row = Math.Max(0, currRow-1); 
                row< Math.Min(currRow+2, 16); row++)
            {
                for (int col = Math.Max(currCol-1, 0);
                    col < Math.Min(currCol+2, 16); col ++)
                {
                    crumbCounter += theTray[row][col] - '0';
                }
            }

            if ( crumbCounter==9)
            {
                currReply = "cookie";
            }
            else if ( crumbCounter == 1 && theTray[currRow][currCol] == '1')
            {
                currReply = "cookie crumb";
            }
            else if ( crumbCounter> 1 && theTray[currRow][currCol] == '1')
            {
                currReply = "broken cookie";
            }
            else
            {
                currReply = "nothing";
            }

            return currReply;
        }

       public static List<char[]> TakeACookie(int takeFromRow, int takeFromCol, List<char[]> Tray)
        {
            //guaranteed to be a full cookie
            for ( int row = takeFromRow-1; row<= takeFromRow +1; row ++ )
            {
                for (int col = takeFromCol-1; col <= takeFromCol+1; col++)
                {
                    Tray[row][col] = '0';
                }
            }

            return Tray;
        }
    }
}
