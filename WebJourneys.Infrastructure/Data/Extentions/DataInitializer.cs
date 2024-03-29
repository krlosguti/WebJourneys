using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Domain.Models;

namespace WebJourneys.Infrastructure.Data.Extentions
{
    public class DataInitializer
    {
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                try
                {
                    if (context.Flights.Any() || context.Transports.Any())
                        return;

                    //recovering flights
                    var path = System.IO.Directory.GetCurrentDirectory();
                    string flightsJSON = System.IO.File.ReadAllText(path + @"\\markets.json");
                    List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(flightsJSON);
                    if (flights != null)
                    {
                        await context.Flights.AddRangeAsync(flights);
                        await context.SaveChangesAsync();
                    }

                    if (context.IATACodes.Any())
                        return;

                    //recovering IATA Codes
                    string iataJSON = System.IO.File.ReadAllText(path + @"\\iata.json");
                    List<IATACode> iataCodes = JsonConvert.DeserializeObject<List<IATACode>>(iataJSON);
                    if (iataCodes != null)
                    {
                        await context.IATACodes.AddRangeAsync(iataCodes);
                        await context.SaveChangesAsync();
                    }
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
                
            }

        }
    }
}
