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
    public class TransportRepository : BaseRepository<Transport>, ITransportRepository
    {
        private readonly ApplicationDbContext _context;
        public TransportRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Transport> GetFlightByCarrierAndNumber(string carrier, string number)
        {
            return await _context.Transports.FirstOrDefaultAsync(x => x.FlightCarrier.Equals(carrier) && x.FlightNumber.Equals(number));
        }
    }
}
