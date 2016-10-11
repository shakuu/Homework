using System;
using System.Linq;

namespace EntitiyTesting.DBModels
{
    public static class MyClass
    {
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers
                    .Select(c => new
                    {
                        c.ContactName,
                        c.City
                    })
                .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.ContactName} From {customer.City}");
                }
            }
        }
    }
}
