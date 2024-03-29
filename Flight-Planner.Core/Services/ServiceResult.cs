﻿using System.Collections.Generic;
using Flight_Planner.Core.Interfaces;

namespace Flight_Planner.Core.Services
{
    public class ServiceResult
    {
        public bool Succeeded { get; private set; } //private to avoid changes
        public int Id { get; }
        public IEntity Entity { get; private set; }

        public IEnumerable<string> Errors = new List<string>();   //implements any type of collection

        public ServiceResult(bool succeeded)
        {
            Succeeded = succeeded;
        }


        public ServiceResult(int id, bool succeeded)
        {
            Id = id;
            Succeeded = succeeded;
        }
        public ServiceResult Set(IEnumerable<string> errors)
        {
            Errors = errors;
            return this;
        }

        public ServiceResult Set(IEntity entity)  //object returns itself
        {
            Entity = entity;
            return this;
        }
    }
}
