using BlazorCustomerAppointmnet.Client.Contracts;
using BlazorCustomerAppointmnet.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.Services
{
    public class CustomerSupportAppointmentService : ICustomerSupportAppointmentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/customerSupportAppointments";

        public CustomerSupportAppointmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddEntities(List<CustomerSupportAppointment> newEntities)
        {
            await _httpClient.PostJsonAsync($"{_baseUrl}/addmultiple", newEntities);
        }

        public async Task<CustomerSupportAppointment> AddEntity(CustomerSupportAppointment newEntity)
        {
            return await _httpClient.PostJsonAsync<CustomerSupportAppointment>(_baseUrl, newEntity);
        }

      
        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task DeleteEntity(int idAppointment, int idCustomerSupport)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{idAppointment}/{idCustomerSupport}");
        }

        public async Task<IEnumerable<CustomerSupportAppointment>> GetAll()
        {
            return await _httpClient.GetJsonAsync<CustomerSupportAppointment[]>(_baseUrl);
        }

        public async Task<CustomerSupportAppointment> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<CustomerSupportAppointment>($"{_baseUrl}/{id}");
        }

        public async Task<CustomerSupportAppointment> GetById(int idAppointment, int idCustomerSupport)
        {
            return await _httpClient.GetJsonAsync<CustomerSupportAppointment>($"{_baseUrl}/{idAppointment}/{idCustomerSupport}");
        }

        public async Task<IEnumerable<CustomerSupportAppointment>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<CustomerSupportAppointment[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<CustomerSupportAppointment> UpdateEntity(CustomerSupportAppointment updatedEntity)
        {
            return await _httpClient.PutJsonAsync<CustomerSupportAppointment>($"{_baseUrl}/{updatedEntity.AppointmentID}/{updatedEntity.CustomerSupportID}", updatedEntity);
        }
    }
}
