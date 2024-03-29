using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJourneys.Domain.Models
{
    public class IATACode
    {
        public string CountryCode { get; set; }
        public string RegionName { get; set; }
        [Key]
        public string IATA {  get; set; }
        public string ICAO { get; set; }
        public string Airport { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
