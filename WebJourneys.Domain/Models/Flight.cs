using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebJourneys.Domain.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public int TransportId { get; set; }
        public Transport Transport { get; set; }
        public async Task<double> ExchangeRate (string money) 
        {
            //Recovering exchange
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://v6.exchangerate-api.com/v6/b033f9c3c2db55cc0858d44e/pair/USD/{money}/{Price}")) 
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(apiResponse);
                        var value = json.SelectToken("conversion_result");
                    }
                }
            }
            return 0;
        }
    }
}
