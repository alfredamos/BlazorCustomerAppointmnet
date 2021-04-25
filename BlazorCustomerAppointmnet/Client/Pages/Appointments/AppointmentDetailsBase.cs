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
    public class AppointmentDetailsBase : ComponentBase
    {
        [Inject]
        public IAppointmentService AppointmentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Appointment AppointmentDB { get; set; } = new Appointment();

        public AppointmentView Appointment { get; set; } = new AppointmentView();

        protected ConfirmDelete DeleteConfirmation { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        protected async override Task OnInitializedAsync()
        {
            AppointmentDB = await AppointmentService.GetById(Id);
            CustomerName = AppointmentDB.Customer.FullName;
            CustomerEmail = AppointmentDB.Customer.Email;
            CustomerPhone = AppointmentDB.Customer.PhoneNumber;


            Mapper.Map(AppointmentDB, Appointment);
            
           
        }

        protected void UpdateAppointment(int appointmentId)
        {           
            
            NavigationManager.NavigateTo($"/editAppointment/{appointmentId}");
           
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task AppointmentToDelete(bool deteConfirmed)
        {
            Mapper.Map(Appointment, AppointmentDB);

            if (deteConfirmed)
            {
                await AppointmentService.DeleteEntity(Id);

            }
            NavigationManager.NavigateTo("/appointmentList");

        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/appointmentList");
        }


    }
}

