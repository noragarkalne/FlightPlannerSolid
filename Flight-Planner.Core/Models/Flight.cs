using System.ComponentModel.DataAnnotations;

namespace Flight_Planner.Core.Models
{
    public class Flight : Entity
    {
        public virtual Airport To { get; set; } //lazy loading -virtual
        
        public virtual Airport From { get; set; } //lazy loading - virtual
        [ConcurrencyCheck]
        public string Carrier { get; set; }
        [ConcurrencyCheck]
        public string DepartureTime { get; set; }
        [ConcurrencyCheck]
        public string ArrivalTime { get; set; }
       

        public override bool Equals(object obj)
        {
            var flight = obj as Flight;

            if (flight == null)
            {
                return false;
            }

            if (this.To.Equals(flight.To) &&
                this.From.Equals(flight.From) &&
                this.Carrier == flight.Carrier &&
                this.DepartureTime == flight.DepartureTime &&
                this.ArrivalTime == flight.ArrivalTime)
            {
                return true;
            }

            return false;
        }
    }
}
