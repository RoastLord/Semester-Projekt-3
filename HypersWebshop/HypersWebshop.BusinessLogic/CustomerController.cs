using HypersWebshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HypersWebshop.DataAccessLayer;

namespace HypersWebshop.BusinessLogic
{
    public class CustomerController : ICRUD<Customer>
    {
        DBCustomer dBCustomer = new DBCustomer();

        public void Create(Customer entity)
        {
            dBCustomer.Create(entity);
            dBCustomer.CreateCustomer();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll(Enum productDescription)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
