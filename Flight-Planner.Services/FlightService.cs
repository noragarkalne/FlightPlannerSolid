using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_Planner.Core.Interfaces;
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
    }
}
