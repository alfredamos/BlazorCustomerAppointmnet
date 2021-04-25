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
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/customers";

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Customer> AddEntity(Customer newEntity)
        {
            return await _httpClient.PostJsonAsync<Customer>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Customer[]>(_baseUrl);
        }

        public async Task<Customer> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Customer>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Customer>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<Customer[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<Customer> UpdateEntity(Customer updatedEntity)
        {
            return await _httpClient.PutJsonAsync<Customer>($"{_baseUrl}/{updatedEntity.CustomerID}", updatedEntity);
        }
    }
}
