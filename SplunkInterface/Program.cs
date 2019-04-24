
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Splunk.Client;
using System.Net;
using System.Threading;
using Application = System.Windows.Forms.Application;

namespace SplunkInterface
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // count(200);
            // async stuff//Console.WriteLine("sapeee");






            //plunkSession.InitializeClient();

           Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
        public static async Task run(string query, ListBox logger)
        {
            logger.Items.Clear();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            var service = new Service(new Uri("https://192.168.1.103:8089"));

            //login
            await service.LogOnAsync("Administrator", "pa$$word1");

            //create a One Shot Search and retrieve the results
            var searchResults = await service.SearchOneShotAsync("search " + query);
     
            //loop through the results
            var recordNumber = 0;
            foreach (var result in searchResults)
            {
                //write out the raw event

                logger.Items.Add("\n"+ result);
                Console.WriteLine(string.Format("{0:D8}: {1}", ++recordNumber, result ));
               
            }
            Console.WriteLine("search " + query);
        }

        




    }


}
