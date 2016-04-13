using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine1
{

    class Program
    {
        static void Main()
        {
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


            if ( devPayment>= toPay )
            {
                if ( machineWallet>= (devPayment-toPay))
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
