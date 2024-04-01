using MediatR.NotificationPublishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJourneys.Application.Dtos
{
    public class City
    {
        public string IATA { get; set; }
        public string Airport { get; set; }  
    }
}
