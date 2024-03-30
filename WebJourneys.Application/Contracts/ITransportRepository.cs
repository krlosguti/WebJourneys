using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.Contracts.Base;
using WebJourneys.Domain.Models;

namespace WebJourneys.Application.Contracts
{
    public interface ITransportRepository
    {
        Task<Transport> GetFlightByCarrierAndNumber(string carrier, string number);
    }
}
