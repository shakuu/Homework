using EntityFramework.Data;
using EntitiyFramework.Tasks;
using System.Data.Entity;
using System.Linq;

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
            foreach (var customer in customers)
            {
                System.Console.WriteLine($"Name: {customer.ContactName}, Country: {customer.Country}");
            }
        }

        private static void CustomersWithOrdersFromYearToCountryWithSQL(int year, string country)
        {
            var queryTemplate = @"SELECT DISTINCT *
                    FROM Customers c
                    JOIN Orders o
                        ON o.CustomerID = c.CustomerID
                    WHERE o.ShipCountry = '{1}' AND YEAR(o.OrderDate) = {0}";
            var query = string.Format(queryTemplate, year, country);

            var context = new NorthwindEntities();
            var customers = context.Customers.SqlQuery(query).ToList();
            foreach (var customer in customers)
            {
                System.Console.WriteLine($"Name: {customer.ContactName}, Country: {customer.Country}");
            }
        }
    }
}
