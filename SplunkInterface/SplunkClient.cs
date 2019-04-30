using Splunk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SplunkInterface
{
    public class SplunkClient
    {

        #region fields/properties
        private Service _service;
        private string _user, _password, _baseURL, _port;
        #endregion

        #region constructor
        public SplunkClient(string user, string password, string baseURL, string port)
        {
            _user = user;
            _password = password;
            _baseURL = baseURL;
            _port = port;
        }
        #endregion

        #region public methods
        public void SetSecurity()
        {
            try
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task LoginAsync()
        {
            try
            {
                _service = new Service(new Uri("https://" + _baseURL + ":" + _port));
                await _service.LogOnAsync(_user, _password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public async Task<bool> VerifyConnectionAsync()
        {
            try
            {  
                var searchResults = await _service.SearchOneShotAsync("search index=main");
                return searchResults != null ? true : false;
            } catch
            {
                return false;
            }
        }

        public async Task<SearchResultStream> GetCurrentValueAsync(string attribute)
        {
            string query = "index=main | stats latest(_time) as _time, latest("+attribute+") as Value";
            var searchResults = await _service.SearchOneShotAsync("search " + query);
            return searchResults;
        }

        public async Task<SearchResultStream> getHistoricalValueAsync(string attribute, string lookBackDate, string targetDate)
        {
            string query = "index = main earliest = "+lookBackDate+"  latest = "+targetDate+" | stats latest(_time) as _time, latest("+attribute+") as Value";
            var searchResults = await _service.SearchOneShotAsync("search " + query);
            return searchResults;
        }

        public async Task<SearchResultStream> getTrendDataAsync(string attribute, string earliestDate, string latestDate, string bucketSize)
        {
            string query = "index=main earliest=" + earliestDate + "  latest=" + latestDate + " |bucket _time span="+bucketSize+" | stats avg("+attribute+") as Value by _time";
            var searchResults = await _service.SearchOneShotAsync("search " + query);
            return searchResults;
        }

        public async Task<SearchResultStream> OpenQuery(string query)
        {
            var searchResults = await _service.SearchOneShotAsync("search " + query);
            return searchResults;
        }
        #endregion

        #region global methods
        public static void PrintResults(SearchResultStream results, ListBox logger)
        {
            logger.Items.Clear();
            var recordNumber = 0;
            foreach (var result in results)
            {
                logger.Items.Add("\n" + result.GetValue("_time") + "                  : " + result.GetValue("Value"));
                Console.WriteLine(string.Format("{0:D8}: {1}", ++recordNumber, result));

            }
        }
        #endregion

    }
}
