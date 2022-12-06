using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCache
{
    internal class JCDRequest
    {
        private readonly HttpClient _client;
        private const string ApiKey = "e976cd7b636be31b063a4a2b422c15d889a737d5";

        public JCDRequest()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.jcdecaux.com/vls/v3/")
            };
        }

        public string GetStationsByContract(string contract)
        {
            return GetRequest("stations?contract=" + contract + "&apiKey=" + ApiKey).Result;
        }

        public string GetAllStations()
        {
            return GetRequest("stations?apiKey=" + ApiKey).Result;
        }

        private async Task<string> GetRequest(string url)
        {
            return await _client.GetAsync(url).Result.Content.ReadAsStringAsync();
        }
    }
}
