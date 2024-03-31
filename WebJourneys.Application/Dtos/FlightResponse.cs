using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebJourneys.Domain.Models;

namespace WebJourneys.Application.Dtos
{
    public class FlightResponse
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public string Coin { get; set; } = "USD";
        public double PriceCoin { get; set; }
        public int TransportId { get; set; }
        public string NameTransport {  get; set; }
        
    }
}
