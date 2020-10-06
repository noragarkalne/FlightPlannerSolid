using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner_Data;



namespace Flight_Planner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            return await Query().ToListAsync();
        }
        public async Task<Flight> GetFlight(int id)
        {
            return await GetById<Flight>(id);
        }
        public async Task<ServiceResult> AddFlights(Flight flight)
        {
            var flights = await GetFlights();

            if (flights.Any(f => f.Equals(flight)))
            {
                return new ServiceResult(false);
            }

            return Create(flight); 
        }

        public void ClearFlights()
        {
            _ctx.Flights.RemoveRange(_ctx.Flights);
            _ctx.Airports.RemoveRange(_ctx.Airports);
            _ctx.SaveChanges();
        }

        public async Task<ServiceResult> DeleteFlight(int id)
        {
            var flights = await GetFlights();
            foreach (var flight in flights)
            {
                if ( flight.Id.Equals(id))
                {
                  return Delete(flight);
                }
            }
            return new ServiceResult(false);
        }


        public bool IsFlightValid(Flight flight)
        {
            if (flight == null)
            {
                return false;
            }

            if (flight.To != null &&
                flight.From != null &&
                !string.IsNullOrEmpty(flight.To.Country) &&
                !string.IsNullOrEmpty(flight.To.City) &&
                !string.IsNullOrEmpty(flight.To.AirportCode) &&
                !string.IsNullOrEmpty(flight.From.Country) &&
                !string.IsNullOrEmpty(flight.From.City) &&
                !string.IsNullOrEmpty(flight.From.AirportCode) &&
                !string.IsNullOrEmpty(flight.Carrier) &&
                !string.IsNullOrEmpty(flight.DepartureTime) &&
                !string.IsNullOrEmpty(flight.ArrivalTime) &&
                Convert.ToDateTime(flight.DepartureTime) < Convert.ToDateTime(flight.ArrivalTime))
            {
                return true;
            }

            return false;
        }

        public bool IsAirportValid(Flight flight)
        {
            if (flight == null)
            {
                return false;
            }

            if (!flight.To.AirportCode.ToLower().Trim().Equals(flight.From.AirportCode.ToLower().Trim()) &&
                !flight.To.Equals(flight.From))
            {
                return true;
            }

            return false;
        }
        
        public async Task<HashSet<Airport>> SearchByIncompletePhrases(string search)
        {
            var flights = await GetFlights();
            var flightTo = flights.Where(x => x.To.Country.ToString().ToLower().Contains(search.ToLower().Trim()) ||
                                              x.To.City.ToString().ToLower().Contains(search.ToLower().Trim()) ||
                                              x.To.AirportCode.ToString().ToLower().Contains(search.ToLower().Trim())).Select(y => y.To).ToList();
            var flightFrom = flights.Where(x => x.From.Country.ToString().ToLower().Contains(search.ToLower().Trim()) ||
                                                x.From.City.ToString().ToLower().Contains(search.ToLower().Trim()) ||
                                                x.From.AirportCode.ToString().ToLower().Contains(search.ToLower().Trim())).Select(y => y.From).ToList();

            var result = flightTo.Concat(flightFrom).ToHashSet();
            return result;
        }
    }
}
