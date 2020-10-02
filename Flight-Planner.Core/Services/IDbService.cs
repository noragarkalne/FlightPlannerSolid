﻿using Flight_Planner.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Planner.Core.Services
{
    public interface IDbService
    {
        IQueryable<T> Query<T>() where T: Entity;
        IQueryable<T> QueryById<T>(int id) where T : Entity;
        IEnumerable<T> Get<T>() where T : Entity;
        Task<T> GetById<T>(int id) where T : Entity;
        ServiceResult Create<T>(T entity) where T : Entity;
        ServiceResult Delete<T>(T entity) where T : Entity;
        ServiceResult Update<T>(T entity) where T : Entity;
        bool Exists<T>(int id) where T : Entity;
    }
}

//visam klasem kas mantosies no Entity visas sis funkcijas ies
