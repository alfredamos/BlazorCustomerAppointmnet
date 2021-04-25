using BlazorCustomerAppointmnet.Server.Contracts;
using BlazorCustomerAppointmnet.Server.Data;
using BlazorCustomerAppointmnet.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Server.SQL
{
    public class SQLCustomerSupportAppointmentRepository : ICustomerSupportAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLCustomerSupportAppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CustomerSupportAppointment> AddEntity(CustomerSupportAppointment newEntity)
        {
            var customerSupportAppointment = await _context.CustomerSupportAppointments.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return customerSupportAppointment.Entity;
        }

        public async Task<CustomerSupportAppointment> DeleteEntity(int id)
        {
            var customerSupportAppointmentToDelete = await _context.CustomerSupportAppointments.FindAsync(id);

            if (customerSupportAppointmentToDelete != null)
            {
                _context.CustomerSupportAppointments.Remove(customerSupportAppointmentToDelete);
                await _context.SaveChangesAsync();
            }

            return customerSupportAppointmentToDelete;
        }

        public async Task<CustomerSupportAppointment> DeleteEntity(int idAppointment, int idCustomerSupport)
        {
            var customerSupportAppointmentToDelete = await _context.CustomerSupportAppointments
                          .FirstOrDefaultAsync(x => x.AppointmentID == idAppointment && x.CustomerSupportID == idCustomerSupport);

            if (customerSupportAppointmentToDelete != null)
            {
                _context.CustomerSupportAppointments.Remove(customerSupportAppointmentToDelete);
                await _context.SaveChangesAsync();

            }
            return customerSupportAppointmentToDelete;
        }

        public async Task<IEnumerable<CustomerSupportAppointment>> GetAll()
        {
            return await _context.CustomerSupportAppointments.Include(x => x.CustomerSupport)
                                 .Include(x => x.Appointment)
                                 .ThenInclude(x => x.Customer)                         
                                 .ToListAsync();
        }

        public async Task<CustomerSupportAppointment> GetById(int id)
        {
            return await _context.CustomerSupportAppointments.Include(x => x.CustomerSupport)
                                 .Include(x => x.Appointment)
                                 .ThenInclude(x => x.Customer)
                                 .FirstOrDefaultAsync(x => x.AppointmentID == id);
        }

        public async Task<CustomerSupportAppointment> GetById(int idAppointment, int idCustomerSupport)
        {
            return await _context.CustomerSupportAppointments.Include(x => x.CustomerSupport)
                                 .Include(x => x.Appointment)
                                 .ThenInclude(x => x.Customer)
                                 .FirstOrDefaultAsync(x => x.AppointmentID == idAppointment 
                                 && x.CustomerSupportID == idCustomerSupport);
        }

        public async Task<IEnumerable<CustomerSupportAppointment>> Search(string searchKey)
        {
            IQueryable<CustomerSupportAppointment> Query = _context.CustomerSupportAppointments;

            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await Query.Include(x => x.Appointment)
                         .ThenInclude(x => x.Customer)
                         .Include(x => x.CustomerSupport).ToListAsync();
            }

            return await Query
                         .Include(x => x.Appointment)
                         .ThenInclude(x => x.Customer)
                         .Include(x => x.CustomerSupport)
                         .Where(x => x.Appointment.Customer.Email.Contains(searchKey) ||
                         x.Appointment.Customer.FirstName.Contains(searchKey) ||
                         x.Appointment.Customer.LastName.Contains(searchKey) ||
                         x.Appointment.Customer.PhoneNumber.Contains(searchKey) ||
                         x.CustomerSupport.FirstName.Contains(searchKey) ||
                         x.CustomerSupport.LastName.Contains(searchKey) ||
                         x.CustomerSupport.Role.Contains(searchKey))
                         .ToListAsync();
        }

        public async Task<CustomerSupportAppointment> UpdateEntity(CustomerSupportAppointment updatedEntity)
        {
            var customerSupportAppointment = _context.CustomerSupportAppointments.Attach(updatedEntity);
            customerSupportAppointment.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return customerSupportAppointment.Entity;
        }

    }
}
