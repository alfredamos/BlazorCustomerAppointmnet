using AutoMapper;
using BlazorCustomerAppointmnet.Client.Contracts;
using BlazorCustomerAppointmnet.Client.Shared.UI;
using BlazorCustomerAppointmnet.Client.ViewModels;
using BlazorCustomerAppointmnet.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.Pages.Appointments
{
    public class RemoveCustomerSupportFromAppointmentBase : ComponentBase
    {
        [Inject]
        public ICustomerSupportAppointmentService CustomerSupportAppointmentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int IdAppointment { get; set; }

        [Parameter]
        public int IdCustomerSupport { get; set; }

        public CustomerSupportAppointment CustomerSupportAppointmentDB { get; set; } = new();

        protected ConfirmDelete DeleteConfirmation { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        public string AppointmentName { get; set; }

        public string AppointmentDescription { get; set; }

        public string AppointmentDuration { get; set; }

        public string AppointmentDate { get; set; }

        public string CustomerSupportName { get; set; }

        protected async override Task OnInitializedAsync()
        {
            CustomerSupportAppointmentDB = await CustomerSupportAppointmentService.GetById(IdAppointment, IdCustomerSupport);

            AppointmentDate = CustomerSupportAppointmentDB.Appointment.Date.ToLongDateString();            
            AppointmentDescription = CustomerSupportAppointmentDB.Appointment.Description;
            AppointmentDuration = CustomerSupportAppointmentDB.Appointment.Duration.ToString();
            AppointmentName = CustomerSupportAppointmentDB.Appointment.Name;

            CustomerName = CustomerSupportAppointmentDB.Appointment.Customer.FullName;
            CustomerEmail = CustomerSupportAppointmentDB.Appointment.Customer.Email;
            CustomerPhone = CustomerSupportAppointmentDB.Appointment.Customer.PhoneNumber;

            CustomerSupportName = CustomerSupportAppointmentDB.CustomerSupport.FullName;

        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task DeleteCustomerSupportAppointment(bool deleteConfirmed)
        {          
            if (deleteConfirmed)
            {
                await CustomerSupportAppointmentService.DeleteEntity(IdAppointment, IdCustomerSupport);

            }
            NavigationManager.NavigateTo("confirmedAppointments");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("confirmedAppointments");
        }

    }
}
