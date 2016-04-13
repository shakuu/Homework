using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine1
{
    class Coins
    {
        public double Value;
        public int Available;

        public Coins(double val, int amount)
        {
            this.Value = val;
            this.Available = amount;
        }
    }

    class Program
    {
        static void Main()
        {

            //Get Coins
            //Coins[] machineWallet = new Coins[5];

            //machineWallet[0] = new Coins(0.05, int.Parse(Console.ReadLine()));
            //machineWallet[1] = new Coins(0.10, int.Parse(Console.ReadLine()));
            //machineWallet[2] = new Coins(0.20, int.Parse(Console.ReadLine()));
            //machineWallet[3] = new Coins(0.50, int.Parse(Console.ReadLine()));
            //machineWallet[4] = new Coins(1.00, int.Parse(Console.ReadLine()));

            double machineWallet = 0;
            int amount = 0;
            for ( int i = 0; i< 5; i++)
            {
                amount = int.Parse(Console.ReadLine());

                switch(i)
                {
                    case 0:
                        machineWallet += (double)amount * (double)0.05;
                        break;
                    case 1:
                        machineWallet += (double)amount * (double)0.10;
                        break;
                    case 2:
                        machineWallet += (double)amount * (double)0.20;
                        break;
                    case 3:
                        machineWallet += (double)amount * (double)0.50;
                        break;
                    case 4:
                        machineWallet += (double)amount * (double)1;
                        break;
                }

            }

            double devPayment = double.Parse(Console.ReadLine());
            double toPay = double.Parse(Console.ReadLine());


            if ( devPayment> toPay )
            {
                if ( machineWallet> (devPayment-toPay))
                {
                    Console.WriteLine("Yes {0:F2}",machineWallet-(  devPayment-toPay));
                }
                else if ( machineWallet< (devPayment-toPay))
                {
                    Console.WriteLine("No {0:F2}", (devPayment - toPay) - machineWallet);
                }
            }
            else if(devPayment<toPay)
            {
                Console.WriteLine("More {0:F2}", toPay - devPayment);
            }
        }
    }
}
