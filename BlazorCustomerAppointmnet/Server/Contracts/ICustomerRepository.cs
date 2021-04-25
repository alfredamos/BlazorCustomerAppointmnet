using BlazorCustomerAppointmnet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Server.Contracts
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }
}
