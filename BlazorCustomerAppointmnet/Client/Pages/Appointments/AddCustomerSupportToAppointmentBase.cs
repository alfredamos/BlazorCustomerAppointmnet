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
    public class AddCustomerSupportToAppointmentBase : ComponentBase
    {
        [Inject]
        public IAppointmentService AppointmentService { get; set; }

        [Inject]
        public ICustomerSupportService CustomerSupportService { get; set; }

        [Inject]
        public ICustomerSupportAppointmentService CustomerSupportAppointmentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Appointment AppointmentDB { get; set; } = new();

        public AppointmentView Appointment { get; set; } = new();

        public List<CustomerSupport> SupportEmployeesDB { get; set; } = new();

        public List<CustomerSupportView> SupportEmployees { get; set; } = new();

        public CustomerSupportAppointment CustomerSupportAppointmentDB { get; set; } = new();

        public CustomerSupportAppointmentView CustomerSupportAppointment { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            AppointmentDB = await AppointmentService.GetById(Id);
            SupportEmployeesDB = (await CustomerSupportService.GetAll()).ToList();

            CustomerSupportAppointment.AppointmentID = AppointmentDB.AppointmentID;

            Console.WriteLine("AppointmentID : " + CustomerSupportAppointment.AppointmentID);

            Mapper.Map(AppointmentDB, Appointment);
            Mapper.Map(SupportEmployeesDB, SupportEmployees);
        }

        protected async Task CreateCustomerSupportAppointment()
        {            
            Mapper.Map(CustomerSupportAppointment, CustomerSupportAppointmentDB);

            var customerSupportAppointment = await CustomerSupportAppointmentService.AddEntity(CustomerSupportAppointmentDB);

            if (customerSupportAppointment != null)
            {
                NavigationManager.NavigateTo("confirmedAppointments");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("confirmedAppointments");
        }
    }
}
