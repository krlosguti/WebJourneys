using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJourneys.Domain.Models
{
    public class Transport
    {
        public int Id { get; set; }
        public string FlightCarrier { get; set; } = string.Empty;
        public string FlightNumber { get; set; } = string.Empty;
        public string GetVuelo() => FlightCarrier + FlightNumber;
    }
}
