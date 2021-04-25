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
    public class CustomerSupportService : ICustomerSupportService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/supportEmployees";

        public CustomerSupportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CustomerSupport> AddEntity(CustomerSupport newEntity)
        {
            return await _httpClient.PostJsonAsync<CustomerSupport>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<CustomerSupport>> GetAll()
        {
            return await _httpClient.GetJsonAsync<CustomerSupport[]>(_baseUrl);
        }

        public async Task<CustomerSupport> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<CustomerSupport>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<CustomerSupport>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<CustomerSupport[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<CustomerSupport> UpdateEntity(CustomerSupport updatedEntity)
        {
            return await _httpClient.PutJsonAsync<CustomerSupport>($"{_baseUrl}/{updatedEntity.CustomerSupportID}", updatedEntity);
        }
    }
}
