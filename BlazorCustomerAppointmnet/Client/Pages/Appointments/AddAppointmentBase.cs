using AutoMapper;
using BlazorCustomerAppointmnet.Client.Contracts;
using BlazorCustomerAppointmnet.Client.ViewModels;
using BlazorCustomerAppointmnet.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.Pages.Appointments
{
    public class AddAppointmentBase : ComponentBase
    {
        [Inject]
        public IAppointmentService AppointmentService { get; set; }

        [Inject]
        public ICustomerService CustomerService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public Appointment AppointmentDB { get; set; } = new Appointment();

        public AppointmentView Appointment { get; set; } = new AppointmentView();

        public List<Customer> CustomersDB { get; set; } = new();

        public List<CustomerView> Customers { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            CustomersDB = (await CustomerService.GetAll()).ToList();

            Mapper.Map(CustomersDB, Customers);
        }

        protected async Task CreateAppointment()
        {
            Mapper.Map(Appointment, AppointmentDB);

            var appointment = await AppointmentService.AddEntity(AppointmentDB);

            if (appointment != null)
            {
                NavigationManager.NavigateTo("/appointmentList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/appointmentList");
        }
    }
}
