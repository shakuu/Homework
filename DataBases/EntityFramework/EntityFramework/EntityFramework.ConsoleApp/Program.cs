using System.Linq;

using EntityFramework.Data;
using EntitiyFramework.Tasks;

namespace EntityFramework.ConsoleApp
{
    public class Program
    {
        private const string CustomerId = "ASDFG";

        public static void Main()
        {
            Program.InsertCustomer(Program.CustomerId, "Company");
            Program.ModifyCustomer(Program.CustomerId);
            Program.RemoveCustomer(Program.CustomerId);

            Program.CustomersWithOrdersFromYearToCountry(1997, "Canada");
            Program.CustomersWithOrdersFromYearToCountryWithSQL(1997, "Canada");
        }

        private static void InsertCustomer(string id, string companyName)
        {
            var customer = new Customer()
            {
                CustomerID = id,
                CompanyName = companyName
            };

            DAO.InsertCustomer(customer);
        }

        private static void ModifyCustomer(string id)
        {
            var customer = DAO.GetById(id);
            customer.ContactName = "contact name";
            DAO.ModifyCustomer(customer);
        }

        private static void RemoveCustomer(string id)
        {
            var customer = DAO.GetById(id);
            DAO.RemoveCustomer(customer);
        }

        private static void CustomersWithOrdersFromYearToCountry(int year, string country)
        {
            var customers = DAO.GetCustomersWithOrderYearAndCountry(year, country);

            System.Console.WriteLine("Customers with EF, OrederYear 1997, Country Canada");
            foreach (var customer in customers)
            {
                System.Console.WriteLine($"Name: {customer.ContactName}, Country: {customer.Country}");
            }

            System.Console.WriteLine();
        }

        private static void CustomersWithOrdersFromYearToCountryWithSQL(int year, string country)
        {
            var queryTemplate = @"SELECT *
                    FROM Customers c
                    JOIN Orders o
                        ON o.CustomerID = c.CustomerID
                    WHERE o.ShipCountry = '{1}' AND YEAR(o.OrderDate) = {0}";
            var query = string.Format(queryTemplate, year, country);

            var context = new NorthwindEntities();
            var customers = context.Customers.SqlQuery(query).Distinct().ToList();

            System.Console.WriteLine("Customers with NativeSQL, OrederYear 1997, Country Canada");
            foreach (var customer in customers)
            {
                System.Console.WriteLine($"Name: {customer.ContactName}, Country: {customer.Country}");
            }

            System.Console.WriteLine();
        }
    }
}
