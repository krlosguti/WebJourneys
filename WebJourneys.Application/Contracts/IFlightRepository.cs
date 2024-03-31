using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.Contracts.Base;
using WebJourneys.Domain.Models;

namespace WebJourneys.Application.Contracts
{
    public interface IFlightRepository: IBaseRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetAllFlightsWithOrigin(string Origin);
        Task<IEnumerable<IEnumerable<Flight>>> GetAllFlights(string Origin, string Destination);
        Task<IEnumerable<Flight>> GetAllFlightsWithTransport();
    }
}
