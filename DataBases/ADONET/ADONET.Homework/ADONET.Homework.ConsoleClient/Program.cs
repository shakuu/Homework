using System.Collections.Generic;
using System.Reflection;

using Ninject;

using ADONET.Homework.Logic.CommandProviders.Contracts;
using ADONET.Homework.Logic.ImageServices.Contracts;
using ADONET.Homework.Logic.Models;
using ADONET.Homework.Logic.QueryEngines.Contract;

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
            var imageService = ninject.Get<IImageService>();

            DisplayNumberOfCategories(commandProvider, queryEngine);
            DisplayAllCategories(commandProvider, queryEngine);
            DisplayEachProductWithCategory(commandProvider, queryEngine);
            InsertNewProduct(commandProvider, queryEngine);
            DisplayAllCategoriesWithPictures(commandProvider, queryEngine, imageService);
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

        private static void DisplayAllCategoriesWithPictures(ICommandProvider commandProvider, IQueryEngine queryEngine, IImageService imageService)
        {
            var sql = "SELECT * FROM Categories";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteReaderCommand<CategoryWithPicture>(command);

            var fileNameTemplate = "../../../CategoryPictures/{0}.jpg";
            foreach (var item in result)
            {
                var imageData = item.Picture;
                var fileName = string.Format(fileNameTemplate, item.CategoryName);

                imageService.SaveImageToFile(imageData, fileName);
            }
        }
    }
}
