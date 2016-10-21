using System;
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
        private const string NinjectSqlServer = "SqlServer";
        private const string NinjectSQLite = "SQLite";
        private const string NinjectMySql = "MySql";
        private const string NinjectOleDb = "Ole";
        
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var queryEngine = ninject.Get<IQueryEngine>();
            var imageService = ninject.Get<IImageService>();
            var sqlServerCommandProvider = ninject.Get<ICommandProvider>(Program.NinjectSqlServer);

            //DisplayNumberOfCategories(sqlServerCommandProvider, queryEngine);
            //DisplayAllCategories(sqlServerCommandProvider, queryEngine);
            //DisplayEachProductWithCategory(sqlServerCommandProvider, queryEngine);
            //InsertNewProduct(sqlServerCommandProvider, queryEngine);
            //DisplayAllCategoriesWithPictures(sqlServerCommandProvider, queryEngine, imageService);
            //DisplayProductsMatchingStringReadFromConsole(sqlServerCommandProvider, queryEngine);

            //var oleCommandProvider = ninject.Get<ICommandProvider>(Program.NinjectOleDb);
            //var oleDbConnectionProvider = ninject.Get<IConnectionProvider>(Program.NinjectOleDb);
            //queryEngine.ConnectionProvider = oleDbConnectionProvider;

            //DisplayExcelFile(oleCommandProvider, queryEngine);
            //AddRowToExcelTable(oleCommandProvider, queryEngine);
            //DisplayExcelFile(oleCommandProvider, queryEngine);

            //var mySqlCommandProvider = ninject.Get<ICommandProvider>(Program.NinjectMySql);
            //var mySqlConnectionProvider = ninject.Get<IConnectionProvider>(Program.NinjectMySql);
            //queryEngine.ConnectionProvider = mySqlConnectionProvider;

            //MySqlDisplayAllBooks(mySqlCommandProvider, queryEngine);
            //MySqlDisplayBookByBookName(mySqlCommandProvider, queryEngine);
            //MySqlAddBook(mySqlCommandProvider, queryEngine);

            var sqLiteCommandProvider = ninject.Get<ICommandProvider>(Program.NinjectSQLite);
            var sqLiteConnectionProvider = ninject.Get<IConnectionProvider>(Program.NinjectSQLite);
            queryEngine.ConnectionProvider = sqLiteConnectionProvider;

            SqLiteDisplayAllBooks(sqLiteCommandProvider, queryEngine);
            SqLiteDisplayBookByBookName(sqLiteCommandProvider, queryEngine);
            SqLiteAddBook(sqLiteCommandProvider, queryEngine);
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

        private static void AddRowToExcelTable(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "INSERT INTO Table3 VALUES(1, 'Doncho Minkov', 33)";
            var command = commandProvider.CreateCommand(sql);
            var resultInsert = queryEngine.ExecuteNonQueryCommand(command);
        }

        private static void DisplayProductsMatchingStringReadFromConsole(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var inputToMatch = Console.ReadLine();
            var charsToReplace = new[] { '\'', '%', '"', '\\', '_' };
            foreach (var chr in charsToReplace)
            {
                inputToMatch = inputToMatch.Replace(chr.ToString(), "");
            }

            var stringToMatch = string.Format($"'%{inputToMatch}%'");

            var sql = "SELECT * FROM Products p WHERE p.ProductName LIKE " + stringToMatch;
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteReaderCommand<Product>(command);
        }

        private static void MySqlDisplayAllBooks(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "SELECT Title, Author FROM library.books;";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteReaderCommand<Book>(command);
        }

        private static void MySqlDisplayBookByBookName(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var titleToSearchFor = "Dependency Injection";
            var query = $"'%{titleToSearchFor}%'";

            var sql = "SELECT Title, Author FROM library.books WHERE Title LIKE " + query;
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteReaderCommand<Book>(command);
        }

        private static void MySqlAddBook(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "INSERT INTO library.books (Title, Author, PublishDate, ISBN)" +
                "values('Dependency Injection in .NET', 'Mark Seemann', STR_TO_DATE('5/15/2009', '%c/%e/%Y'), '1234567890')";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteNonQueryCommand(command);
        }

        private static void SqLiteDisplayAllBooks(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "SELECT Title, Author FROM books;";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteReaderCommand<Book>(command);
        }

        private static void SqLiteDisplayBookByBookName(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var titleToSearchFor = "Dependency Injection";
            var query = $"'%{titleToSearchFor}%'";

            var sql = "SELECT Title, Author FROM books WHERE Title LIKE " + query;
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteReaderCommand<Book>(command);
        }

        private static void SqLiteAddBook(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "INSERT INTO books (Title, Author, PublishDate, ISBN)" +
                "values('Dependency Injection in .NET', 'Mark Seemann', date('now'), '1234567890')";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteNonQueryCommand(command);
        }

        private static void CreateSQLiteTable(ICommandProvider commandProvider, IQueryEngine queryEngine)
        {
            var sql = "CREATE TABLE books(id INTEGER PRIMARY KEY, Title VARCHAR, Author VARCHAR, PublishDate VARCHAR, ISBN VARCHAR)";
            var command = commandProvider.CreateCommand(sql);
            var result = queryEngine.ExecuteNonQueryCommand(command);
        }
    }
}
