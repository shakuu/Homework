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
    }
}
