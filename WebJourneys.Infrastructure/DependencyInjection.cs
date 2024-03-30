using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.Contracts;
using WebJourneys.Infrastructure.Contracts;
using WebJourneys.Infrastructure.Data;

namespace WebJourneys.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //connection string
            services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase("DBJourneys"));


            services.AddTransient<IFlightRepository, FlightRepository>();
            services.AddTransient<ITransportRepository, TransportRepository>();

            return services;
        }
    }
}
