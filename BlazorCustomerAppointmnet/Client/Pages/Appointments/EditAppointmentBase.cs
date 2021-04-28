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
    public class EditAppointmentBase : ComponentBase
    {
        [Inject]
        public IAppointmentService AppointmentService { get; set; }

        [Inject]
        public ICustomerService CustomerService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Appointment AppointmentDB { get; set; } = new();

        public AppointmentView Appointment { get; set; } = new();

        public List<Customer> CustomersDB { get; set; } = new();

        public List<CustomerView> Customers { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            AppointmentDB = await AppointmentService.GetById(Id);
            Mapper.Map(AppointmentDB, Appointment);

            CustomersDB = (await CustomerService.GetAll()).ToList();
            Mapper.Map(CustomersDB, Customers);
        }

        protected async Task UpdateAppointment()
        {
            Mapper.Map(Appointment, AppointmentDB);

            var appointment = await AppointmentService.UpdateEntity(AppointmentDB);

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
