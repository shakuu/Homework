namespace TradeAndTravel
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine(new MyInteractionManager());
            engine.Start();
        }
    }
}
