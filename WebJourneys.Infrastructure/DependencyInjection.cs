using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddTransient<IIATARepository, IATARepository>();

            return services;
        }
    }
}
