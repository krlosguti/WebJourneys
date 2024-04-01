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
    public class IATARepository : BaseRepository<IATACode>, IIATARepository
    {
        private readonly ApplicationDbContext _context;
        public IATARepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IATACode>> GetAllAvailable()
        {
            List<string> availableOrigin = await _context.Flights.Select(x => x.Origin).Distinct().ToListAsync();
            List<string> availableDestination = await _context.Flights.Select(x => x.Destination).Distinct().ToListAsync();
            var iatas = await _context.IATACodes.Where(x => availableOrigin.Contains(x.IATA) || availableDestination.Contains(x.IATA)).ToListAsync();
            return iatas;
        }
    }
}
