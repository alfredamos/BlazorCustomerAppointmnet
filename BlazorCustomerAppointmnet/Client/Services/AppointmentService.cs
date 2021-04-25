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
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/appointments";

        public AppointmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Appointment> AddEntity(Appointment newEntity)
        {
            return await _httpClient.PostJsonAsync<Appointment>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Appointment[]>(_baseUrl);
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Appointment>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Appointment>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<Appointment[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<Appointment> UpdateEntity(Appointment updatedEntity)
        {
            return await _httpClient.PutJsonAsync<Appointment>($"{_baseUrl}/{updatedEntity.AppointmentID}", updatedEntity);
        }
    }
}
