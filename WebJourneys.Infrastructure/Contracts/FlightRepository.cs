using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.Contracts;
using WebJourneys.Domain.Models;
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

        public async Task<IEnumerable<Flight>> GetAllFlightsWithOrigin(string Origin)
        {
            return await _context.Set<Flight>().Include(x => x.Transport).Where(o => o.Origin.Equals(Origin)) .ToListAsync();
        }
    }
}
