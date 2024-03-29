using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Domain.Models;

namespace WebJourneys.Application.Contracts.Persistence
{
    public interface ITransportRepository
    {
        Task<IEnumerable<Transport>> GetAlltransport();
        Task<Transport> GetFlightByCarrierAndNumber(string carrier, string number);
        Task AddTransport(Transport transport);
        Task UpdateTransport(Transport transport);
        Task DeleteTransport(Transport transport);
    }
}
