﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.BusinessLogic
{
    interface ICRUD<T>
    {
        void Create(T entity);
        IEnumerable<T> GetAll(Enum productDescription);
        void Update(T entity);
        void Delete(T entity);
    }
}
