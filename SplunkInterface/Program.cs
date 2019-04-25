
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
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Form1());

        }

       public static SplunkClient client = new SplunkClient("Administrator", "pa$$word1", "192.168.1.103", "8089");




    }


}
