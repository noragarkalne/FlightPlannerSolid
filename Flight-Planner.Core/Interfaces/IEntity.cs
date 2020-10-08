using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Planner.Core.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
