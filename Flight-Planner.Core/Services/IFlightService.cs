using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {

        Task<IEnumerable<Flight>> GetFlights();
        Task<ServiceResult> AddFlights(Flight flight);
        
        void ClearFlights();
        bool IsFlightValid(Flight flight);
        bool IsAirportValid(Flight flight);

        Task<ServiceResult> DeleteFlight(int id);
        Task<HashSet<Airport>> SearchByIncompletePhrases(string search);
        Task<Flight> GetFlight(int id);
    }
}
