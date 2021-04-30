using BlazorCustomerAppointmnet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.Contracts
{
    public interface ICustomerSupportAppointmentService : IBaseService<CustomerSupportAppointment>
    {
        Task<CustomerSupportAppointment> GetById(int idAppointment, int idCustomerSupport);
        Task DeleteEntity(int idAppointment, int idCustomerSupport);
        Task AddEntities(List<CustomerSupportAppointment> newEntities);
       
    }
}
