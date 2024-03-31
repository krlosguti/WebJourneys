using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Domain.Models;

namespace WebJourneys.Infrastructure.Common
{
    public class FlightPathFinder
    {
        public List<List<Flight>> FindAllRoutes(List<Flight> flights, string origin, string destination)
        {
            List<List<Flight>> allRoutes = new List<List<Flight>>();

            // function to find paths recursively
            void FindRoutesRecursive(string currentOrigin, List<Flight> currentRoute, HashSet<string> visited)
            {
                if (currentOrigin == destination)
                {
                    allRoutes.Add(new List<Flight>(currentRoute));
                    return;
                }

                foreach (var flight in flights.Where(f => f.Origin == currentOrigin && !visited.Contains(f.Destination)))
                {
                    visited.Add(flight.Destination);
                    currentRoute.Add(flight);
                    FindRoutesRecursive(flight.Destination, currentRoute, visited);
                    currentRoute.Remove(flight);
                    visited.Remove(flight.Destination);
                }
            }

            FindRoutesRecursive(origin, new List<Flight>(), new HashSet<string>() { origin });
            return allRoutes;
        }

    }
}
