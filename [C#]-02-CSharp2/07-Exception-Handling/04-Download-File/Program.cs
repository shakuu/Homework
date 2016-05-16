using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace _04_Download_File
{
    class Program
    {
        static void Main()
        {
            var toDownload = Console.ReadLine();
            var targetFolder = Console.ReadLine();

            // https://msdn.microsoft.com/en-us/library/ez801hhe(v=vs.110).aspx
            // List of exceptions related to
            // WebClient.DownloadFile
            try
            {
                using (var webclient = new WebClient())
                {
                    webclient.DownloadFile(toDownload, targetFolder);
                }
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (WebException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(NotSupportedException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
