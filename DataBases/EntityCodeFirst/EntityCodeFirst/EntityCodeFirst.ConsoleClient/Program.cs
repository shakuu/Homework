using System.Data.Entity;
using System.Linq;

using EntityCodeFirst.Data;
using EntityCodeFirst.Data.Migrations;
using EntityCodeFirst.Models;

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

            var mb = new Motherboard()
            {
                Make = "Asus",
                Model = "ROG"
            };

            var pc1 = db.Computers.Where(comp => comp.Id == 2).FirstOrDefault();
            pc1.MotherBoard = mb;

            db.Computers.Add(pc);
            db.SaveChanges();

            var comps = db.Computers
                .Where(comp => comp.Model == "mine")
                .Select(comp => new
                {
                    Id = comp.Id,
                    Make = comp.Make,
                    Motherboard = comp.MotherBoard.Model
                })
                .ToList();

            foreach (var comp in comps)
            {
                System.Console.WriteLine($"Id: {comp.Id}, Make: {comp.Make}, MB: {comp.Motherboard}");
            }

            var mbs = db.Motherboards.ToList();
            foreach (var mb1 in mbs)
            {
                System.Console.WriteLine(mb1.Id);
            }

            var count = db.Computers.Count();

            System.Console.WriteLine(count);
        }
    }
}
