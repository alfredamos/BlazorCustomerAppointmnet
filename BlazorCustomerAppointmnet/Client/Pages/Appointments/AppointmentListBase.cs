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
    public class AppointmentListBase : ComponentBase
    {
        [Inject]
        public IAppointmentService AppointmentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<Appointment> AppointmentsDB { get; set; } = new List<Appointment>();

        public List<AppointmentView> Appointments { get; set; } = new List<AppointmentView>();

        public string FullName { get; set; }

        protected async override Task OnInitializedAsync()
        {
            AppointmentsDB = (await AppointmentService.GetAll()).ToList();            

            Mapper.Map(AppointmentsDB, Appointments);
        }

        protected async Task HandleSearch(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey)) AppointmentsDB = (await AppointmentService.GetAll()).ToList();
            else AppointmentsDB = (await AppointmentService.Search(searchKey)).ToList();
            Mapper.Map(AppointmentsDB, Appointments);
        }

        protected void CreateAppointment()
        {
            NavigationManager.NavigateTo("/addAppointment");
        }

        protected void UpdateAppointment(int appointmentId)
        {
            NavigationManager.NavigateTo($"/editAppointment/{appointmentId}");
        }

        protected void DeleteAppointment(int appointmentId)
        {
            NavigationManager.NavigateTo($"/deleteAppointment/{appointmentId}");
        }

        protected void DetailAppointment(int appointmentId)
        {
            NavigationManager.NavigateTo($"/appointmentDetails/{appointmentId}");
        }
    }
}
