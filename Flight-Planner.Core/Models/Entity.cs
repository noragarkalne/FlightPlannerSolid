﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_Planner.Core.Interfaces;

namespace Flight_Planner.Core.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
