using System.Data.Entity;
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
                new MigrateDatabaseToLatestVersion<FlightPlannerDbContext, Configuration>()); // if new migration will happen ... everything will happen automatically, user even do not notice it; golden line

        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
    }
}
