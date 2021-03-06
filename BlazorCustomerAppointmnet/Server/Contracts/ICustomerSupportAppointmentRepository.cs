using BlazorCustomerAppointmnet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Server.Contracts
{
    public interface ICustomerSupportAppointmentRepository : IBaseRepository<CustomerSupportAppointment>
    {
        Task<CustomerSupportAppointment> GetById(int idAppointment, int idCustomerSupport);
        Task<CustomerSupportAppointment> DeleteEntity(int idAppointment, int idCustomerSupport);
        Task AddEntities(List<CustomerSupportAppointment> customerSupportAppointments);
        Task DeleteEntities(List<CustomerSupportAppointment> customerSupportAppointments);
    }
}
