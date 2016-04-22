using System;

namespace ShipDamage
{
    class ShipDamage
    {
        static void Main()
        {
            int damagataken = 0;
            int CornerDamage = 25;
            int SideDamage = 50;
            int BodyDamage = 100;

            // SX1, SY1, SX2, SY2, H, CX1, CY1, CX2, CY2, CX3, and CY3

            // get ship coordinates
            int ShipX1 = int.Parse(Console.ReadLine());
            int ShipY1 = int.Parse(Console.ReadLine());
            int ShipX2 = int.Parse(Console.ReadLine());
            int ShipY2 = int.Parse(Console.ReadLine());

            // get horizon line
            int Horizon = int.Parse(Console.ReadLine());

            //get cannon coordinates
            int[] CannonsX = new int[3];
            int[] CannonsY = new int[3];

            for (int cannon = 0; cannon < 3; cannon++)
            {
                CannonsX[cannon] = int.Parse(Console.ReadLine());
                CannonsY[cannon] = int.Parse(Console.ReadLine());
            }

            //get cannon symmetrical cannon Y to H
            int[] CannonsYhit = new int[3];

            for (int cannon = 0; cannon < 3; cannon++)
            {
                CannonsYhit[cannon] = Horizon + (Horizon - CannonsY[cannon]);
            }

            // sort ship x and y so x1, y1 is top left
            if (ShipX1>ShipX2)
            {
                int temp = ShipX2;
                ShipX2 = ShipX1;
                ShipX1 = temp;
            }

            if (ShipY1<ShipY2)
            {
                int temp = ShipY2;
                ShipY2 = ShipY1;
                ShipY1 = temp;
            }

            // Get damage done
            // Check 1: Corners
            for (int cannon = 0; cannon < 3; cannon++)
            {
                //top left Ship X1, Y1
                if (CannonsX[cannon] == ShipX1 
                    && CannonsYhit[cannon] == ShipY1)
                {
                    damagataken += CornerDamage;
                }

                // top right Ship X2, Y1
                if (CannonsX[cannon] == ShipX1
                    && CannonsYhit[cannon] == ShipY2)
                {
                    damagataken += CornerDamage;
                }

                // bottom left Ship X2, Y1
                if (CannonsX[cannon] == ShipX2
                   && CannonsYhit[cannon] == ShipY1)
                {
                    damagataken += CornerDamage;
                }

                // bottom right Ship X2, Y2
                if (CannonsX[cannon] == ShipX2
                   && CannonsYhit[cannon] == ShipY2)
                {
                    damagataken += CornerDamage;
                }
            }

            // Check 2: Sides
            for (int cannon = 0; cannon < 3; cannon++)
            {
                // check top edge - Ship Y1, X1 - X2
                if (CannonsYhit[cannon]==ShipY1 &&
                    CannonsX[cannon] > ShipX1 &&
                    CannonsX[cannon] < ShipX2)
                {
                    damagataken += SideDamage;
                }

                // check bottom edge - Ship Y2, X1 - X2
                if (CannonsYhit[cannon] == ShipY2 &&
                    CannonsX[cannon] > ShipX1 &&
                    CannonsX[cannon] < ShipX2)
                {
                    damagataken += SideDamage;
                }

                // check left edge - Ship X1, Y1 - Y2
                if (CannonsX[cannon] == ShipX1 &&
                    CannonsYhit[cannon] < ShipY1 &&
                    CannonsYhit[cannon] > ShipY2)
                {
                    damagataken += SideDamage;
                }

                // check right edge - Ship X2, Y1 - Y2
                if (CannonsX[cannon] == ShipX2 &&
                    CannonsYhit[cannon] < ShipY1 &&
                    CannonsYhit[cannon] > ShipY2)
                {
                    damagataken += SideDamage;
                }
            }

            // check 3: Body
            for (int cannon = 0; cannon < 3; cannon++)
            {
                if (CannonsX[cannon] > ShipX1 &&
                    CannonsX[cannon] < ShipX2 &&
                    CannonsYhit[cannon] < ShipY1 &&
                    CannonsYhit[cannon] > ShipY2)
                {
                    damagataken += BodyDamage;
                }
            }


            // print output
            Console.WriteLine("{0}%", damagataken);
        }       
    }
}
