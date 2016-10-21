using System.Collections.Generic;
using System.Reflection;

using Ninject;

using ADONET.Homework.Logic.Models;
using ADONET.Homework.Logic.QueryEngines.Contract;
using ADONET.Homework.Logic.CommandProviders.Contracts;

namespace ADONET.Homework.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var commandProvider = ninject.Get<ICommandProvider>();
            var queryEngine = ninject.Get<IQueryEngine>();

            DisplayNumberOfCategories(commandProvider, queryEngine);
            DisplayAllCategories(commandProvider, queryEngine);
            DisplayEachProductWithCategory(commandProvider, queryEngine);
            InsertNewProduct(commandProvider, queryEngine);
        }

        private static void DisplayNumberOfCategories(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "SELECT COUNT(*) FROM Categories";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteScalarCommand<int>(command);
        }

        private static void DisplayAllCategories(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "SELECT * FROM Categories";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteReaderCommand<Category>(command);
        }

        private static void DisplayEachProductWithCategory(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "SELECT p.ProductName, c.CategoryName FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteReaderCommand<ProductWithCategory>(command);
        }

        private static void InsertNewProduct(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "INSERT INTO Products (ProductName, CategoryID, Discontinued) VALUES(@productName, @categoryId, @discontinued)";
            var parameters = new Dictionary<string, string>()
            {
                { "@productName", "new product" },
                { "@categoryId", "2" },
                { "@discontinued", "1"}
            };

            var command = commandProvider.CreateCommand(sql, parameters);
            var rowsAffected = queryEngine.ExecuteNonQueryCommand(command);

            var sqlDisplayNewProduct = "SELECT p.ProductName, c.CategoryName FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID WHERE p.ProductName = 'new product'";
            var commandDisplayNewProduct = commandProvider.CreateCommand(sqlDisplayNewProduct);
            var result = queryEngine.ExecuteReaderCommand<ProductWithCategory>(commandDisplayNewProduct);
        }
    }
}
