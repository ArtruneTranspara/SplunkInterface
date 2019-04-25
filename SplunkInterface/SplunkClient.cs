﻿using Splunk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplunkInterface
{
    public class SplunkClient
    {
        public Boolean loggedIn=false;
        private Service service;
        string user, password, baseURL, port;
        public SplunkClient(string user, string password, string baseURL, string port)
        {
            prep(user, password, baseURL, port);
            this.user = user;
            this.password = password;
            this.baseURL = baseURL;
            this.port = port;
        }
        public async Task prep(string user, string password, string baseURL, string port)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };

            service = new Service(new Uri("https://"+baseURL+":"+port));
            await service.LogOnAsync(user, password);
            loggedIn = true;
        }

        public async Task search(string query, ListBox logger)
        {
            try
            {
                logger.Items.Clear();

                //login

                //create a One Shot Search and retrieve the results
                var searchResults = await service.SearchOneShotAsync("search " + query);

                //loop through the results
                var recordNumber = 0;
                foreach (var result in searchResults)
                {
                    //write out the raw event

                    logger.Items.Add("\n" + result.GetValue("_time") + "                  : " + result.GetValue("Value"));
                    Console.WriteLine(string.Format("{0:D8}: {1}", ++recordNumber, result));

                }
                Console.WriteLine("search " + query);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Attempting to reconnect");
                await prep(user, password, baseURL, port);
                search(query, logger);
            }
        }

    }
}
