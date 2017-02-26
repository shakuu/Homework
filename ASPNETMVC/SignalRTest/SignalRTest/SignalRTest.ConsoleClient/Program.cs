using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRTest.ConsoleClient
{
    public class Program
    {
        private const string Url = "http://localhost:57920";

        static void Main(string[] args)
        {
            CreateConnection().Wait();

            while (true)
            {

            }
        }

        private static async Task CreateConnection()
        {
            var connection = new HubConnection(Program.Url);
            connection.TraceWriter = Console.Out;

            var proxy = connection.CreateHubProxy("ChatHub");

            proxy.On<string, string>("broadcastMessage", (name, message) =>
            {
                Console.WriteLine(name + ": " + message);
            });

            await connection.Start();
            await proxy.Invoke("Send", "me", "console");
        }
    }
}
