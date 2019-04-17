﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.DataAccessLayer.Interfaces
{
    interface ICRUD<T>
    {
        void Create(T entity);
        T Get(int id);
        IEnumerable<T> GetAll(Enum productDescription);
        void Update(T entity, T oldEntity);
        void Delete(T entity);
    }
}
