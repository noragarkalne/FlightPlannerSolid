using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Planner.Core.Models
{
    public class Flight : Entity
    {
        public virtual Airport To { get; set; } //lazy loading -virtual
        public virtual Airport From { get; set; } //lazy loading - virtual
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
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
