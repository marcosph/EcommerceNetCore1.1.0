using System.Linq;
using Gzt.Domain.Interfaces;
using Gzt.Domain.Models;
using Gzt.Infra.Data.Context;

namespace Gzt.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>,  ICustomerRepository
    {
        public CustomerRepository(GztContext context)
            :base(context)
        {

        }       

        public Customer GetByEmail(string email)
        {
            return Find(c => c.Email == email).FirstOrDefault();
        }
    }
}
