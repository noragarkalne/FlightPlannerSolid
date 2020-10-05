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
        //Task<ServiceResult> DeleteById(int id);
        void ClearFlights();
        bool IsFlightValid(Flight flight);
        bool IsAirportValid(Flight flight);
    }
}
