using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner_Data;

namespace Flight_Planner.Services
{
    public class AirportService: EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Airport>> GetAirports()
        {
            return await Query().ToListAsync();
        }

        
    }
}
