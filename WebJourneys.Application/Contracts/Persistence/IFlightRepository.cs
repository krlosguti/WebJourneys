using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Domain.Models;

namespace WebJourneys.Application.Contracts.Persistence
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllFlights();
        Task<IEnumerable<Flight>> GetAllFlightsWithOrigin(string Origin);
        Task AddFlight(Flight flight);
        Task UpdateFlight(Flight flight);
        Task DeleteFlight(Flight flight);
    }
}
