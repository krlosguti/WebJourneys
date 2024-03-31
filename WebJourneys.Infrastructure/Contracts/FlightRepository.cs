using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.Contracts;
using WebJourneys.Domain.Models;
using WebJourneys.Infrastructure.Common;
using WebJourneys.Infrastructure.Contracts.Base;
using WebJourneys.Infrastructure.Data;

namespace WebJourneys.Infrastructure.Contracts
{
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        private readonly ApplicationDbContext _context;
        public FlightRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IEnumerable<Flight>>> GetAllFlights(string Origin, string Destination)
        {
            var flights = await _context.Set<Flight>().Include(x => x.Transport).ToListAsync();
            var pathFinder = new FlightPathFinder();
            var allPaths = pathFinder.FindAllRoutes(flights,Origin, Destination);
            return allPaths;
        }

        public async Task<IEnumerable<Flight>> GetAllFlightsWithOrigin(string Origin)
        {
            return await _context.Set<Flight>().Include(x => x.Transport).Where(o => o.Origin.Equals(Origin)) .ToListAsync();
        }

        public async Task<IEnumerable<Flight>> GetAllFlightsWithTransport()
        {
            var flights = await _context.Set<Flight>().Include(x => x.Transport).ToListAsync();
            return flights;
        }
    }
}
