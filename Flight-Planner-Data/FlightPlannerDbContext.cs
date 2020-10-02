using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner_Data.Migrations;

namespace Flight_Planner_Data
{
    public class FlightPlannerDbContext: DbContext, IFlightPlannerDbContext
    {
        public FlightPlannerDbContext() : base ("flight-planner")
        {
           Database.SetInitializer<FlightPlannerDbContext> (null);

           Database.SetInitializer<FlightPlannerDbContext>(
                new MigrateDatabaseToLatestVersion<FlightPlannerDbContext, Configuration>()); // ja bus jaunas migracijas ... viss notiks automatiski un lietotajs  to pat nemana; golden line

        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
    }
}
