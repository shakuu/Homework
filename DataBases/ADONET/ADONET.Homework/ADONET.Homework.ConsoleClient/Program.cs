using System.Collections.Generic;
using System.Reflection;

using Ninject;

using ADONET.Homework.Logic.CommandProviders.Contracts;
using ADONET.Homework.Logic.ImageServices.Contracts;
using ADONET.Homework.Logic.Models;
using ADONET.Homework.Logic.QueryEngines.Contract;
using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var queryEngine = ninject.Get<IQueryEngine>();
            var imageService = ninject.Get<IImageService>();
            var commandProvider = ninject.Get<ICommandProvider>("Sql");
            
            DisplayNumberOfCategories(commandProvider, queryEngine);
            DisplayAllCategories(commandProvider, queryEngine);
            DisplayEachProductWithCategory(commandProvider, queryEngine);
            InsertNewProduct(commandProvider, queryEngine);
            DisplayAllCategoriesWithPictures(commandProvider, queryEngine, imageService);

            var oleCommandProvider = ninject.Get<ICommandProvider>("Ole");
            var oleDbConnectionProvider = ninject.Get<IConnectionProvider>("Ole");
            queryEngine.ConnectionProvider = oleDbConnectionProvider;
            DisplayExcelFile(oleCommandProvider, queryEngine);
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

            var fileNameTemplate = "../../../../CategoryPictures/{0}.jpg";
            foreach (var item in result)
            {
                var imageData = item.Picture;
                var fileName = string.Format(fileNameTemplate, item.CategoryName);

                imageService.SaveImageToFile(imageData, fileName);
            }
        }

        /// <summary>
        /// This'll throw an exception as Table3 already exists.
        /// </summary>
        /// <param name="commandProvider"></param>
        /// <param name="queryEngine"></param>
        private static void FillTableWithData(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "CREATE TABLE Table3 (ID int, name nvarchar, score int)";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteNonQueryCommand(command);

            var insert = "INSERT INTO Table3 VALUES(1, 'Doncho Minkov', 24)";
            var commandInsert = commandProvider.CreateCommand(insert);
            var resultInsert = queryEngine.ExecuteNonQueryCommand(commandInsert);

            var insert2 = "INSERT INTO Table3 VALUES(1, 'Svetlin Nakov', 25)";
            var commandInsert2 = commandProvider.CreateCommand(insert2);
            var resultInsert2 = queryEngine.ExecuteNonQueryCommand(commandInsert2);

            var insert3 = "INSERT INTO Table3 VALUES(1, 'Nikolay Kostov', 22)";
            var commandInsert3 = commandProvider.CreateCommand(insert3);
            var resultInsert3 = queryEngine.ExecuteNonQueryCommand(commandInsert3);

            var insert4 = "INSERT INTO Table3 VALUES(1, 'Goerge Georgiev', 20)";
            var commandInsert4 = commandProvider.CreateCommand(insert4);
            var resultInsert4 = queryEngine.ExecuteNonQueryCommand(commandInsert4);
        }

        private static void DisplayExcelFile(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "SELECT * FROM Table3";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteReaderCommand<ExcelView>(command);
        }
    }
}
