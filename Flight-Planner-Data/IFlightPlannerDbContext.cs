using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;

namespace Flight_Planner_Data
{
    public interface IFlightPlannerDbContext
    {
        DbSet<T> Set<T>() where T : class; //generic thing
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();

        Task<int> SaveChangesAsync(); //first 4 methods are from DbContext class 
        // async enables possibility in same time do several things

        DbSet<Flight> Flights { get; set; }
        DbSet<Airport> Airports { get; set; }
    }
}
