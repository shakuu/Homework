
namespace AcademyRPG
{
    using System.Collections.Generic;

    public class ExtendedEngine : Engine
    {
        protected List<IGatherer> gatherers;
        protected List<IFighter> fighters;

        public ExtendedEngine()
            : base()
        {
            this.gatherers = new List<IGatherer>();
            this.fighters = new List<IFighter>();
        }

        public override void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "giant":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Giant(name, position, owner));
                        break;
                    }
                case "knight":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Knight(name, position, owner));
                        break;
                    }
                case "house":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        int owner = int.Parse(commandWords[3]);
                        this.AddObject(new House(position, owner));
                        break;
                    }
                case "rock":
                    {
                        int size = int.Parse(commandWords[2]);
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Rock(size, position));
                        break;
                    }
                case "ninja":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Ninja(name, position, owner));
                        break;
                    }
                default:
                    base.ExecuteCreateObjectCommand(commandWords);
                    break;
            }
        }
    }
}
