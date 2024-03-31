using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJourneys.Application.Dtos
{
    public class Journey
    {
        public List<FlightResponse> Flights { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; } 
        public double Price { get; set; }
        public string Coin { get; set; } = "USD";
    }
}
