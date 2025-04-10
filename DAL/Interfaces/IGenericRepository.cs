﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

        IEnumerable<T> GetAll();

        T GetbyId(int id);

    }
}
