using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RoutingServer
{
    internal class OSMRequest
    {
        private readonly HttpClient _client;
        private const string _apiKey = "LijBPDQGfu7Iiq80w3HzwB4RUDJbMbhs6BU0dEnn";

        public OSMRequest()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://graphhopper.com/api/1/")
            };
        }

        public string GetItinerary(double latOrigin, double lonOrigin, double latDest, double lonDest, bool bike)
        {
            string vehicle = bike ? "bike" : "foot";

            string json = GetRequest("route?" +
                "vehicle=" + vehicle +
                "&locale=fr" +
                "&key=" + _apiKey +
                "&type=json" +
                "&points_encoded=false" +
                "&point=" + latOrigin.ToString().Replace(',', '.') + "," + lonOrigin.ToString().Replace(',', '.') +
                "&point=" + latDest.ToString().Replace(',', '.') + "," +  lonDest.ToString().Replace(',', '.'))
                .Result;

            return JObject.Parse(json)["paths"].First().ToString();
        }

        public string GetAddressDetails(string address)
        {
            var EncodedAddress = HttpUtility.UrlEncode(address);

            string json = GetRequest("geocode?" +
                "locale=fr" +
                "&q=" + EncodedAddress +
                "&limit=1" +
                "&key=" + _apiKey)
                .Result;

            // Check if address exists
            JToken parse = JObject.Parse(json)["hits"];;       
            if (!parse.HasValues)
                return null;

            return parse.First().ToString();
        }

        private async Task<String> GetRequest(string url)
        {
            return await _client.GetAsync(url).Result.Content.ReadAsStringAsync();
        }
    }
}
