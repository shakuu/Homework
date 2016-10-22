using System.Linq;
using System.Data.Entity;

using EntityCodeFirst.Data;
using EntityCodeFirst.Models;
using EntityCodeFirst.Data.Migrations;

namespace EntityCodeFirst.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputerDbContext, Configuration>());

            var db = new ComputerDbContext();

            var pc = new PersonalComputer()
            {
                Make = "Asus",
                Model = "mine"
            };

            db.Computers.Add(pc);
            db.SaveChanges();

            var comps = db.Computers.Where(comp => comp.Model == "mine").ToList();
            foreach (var comp in comps)
            {
                System.Console.WriteLine(comp.Id);
                System.Console.WriteLine(comp.Make);
            }

            var count = db.Computers.Count();

            System.Console.WriteLine(count);
        }
    }
}
