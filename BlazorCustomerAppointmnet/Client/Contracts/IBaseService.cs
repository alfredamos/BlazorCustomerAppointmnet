using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.Contracts
{
    public interface IBaseService<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> AddEntity(T newEntity);
        Task DeleteEntity(int id);
        Task<T> UpdateEntity(T updatedEntity);
        Task<IEnumerable<T>> Search(string searchKey);
    }
}
