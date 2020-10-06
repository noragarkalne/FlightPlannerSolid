using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Services
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> GetAirports();
    }
}
