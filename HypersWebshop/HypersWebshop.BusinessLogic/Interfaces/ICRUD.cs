using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.BusinessLogic
{
    interface ICRUD<T>
    {
        void create(T entity);
        T Get(string phoneNo);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
    }
}
