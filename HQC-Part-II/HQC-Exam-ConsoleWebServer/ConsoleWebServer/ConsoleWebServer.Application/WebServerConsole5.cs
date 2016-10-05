using System;using System.Linq;
using System.Text;
public class WebServerConsole5 {
    private readonly ResponseProvider responseProvider;
    public WebServerConsole5() {
        this.responseProvider = new ResponseProvider();
    }public void Start() {
        var requestBuilder = new StringBuilder();
        string inputLine;
        while ((inputLine = Console.ReadLine()) != null) {
            if (string.IsNullOrWhiteSpace(inputLine)) {
                var response = this.responseProvider.GetResponse(requestBuilder.ToString());
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(response);
                Console.ResetColor();
                requestBuilder.Clear();
                continue;
            }
            requestBuilder.AppendLine(inputLine);
        }
    }
}