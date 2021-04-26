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
    public class ConfirmedAppointmentsBase : ComponentBase
    {
        [Inject]
        public IAppointmentService AppointmentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public Appointment AppointmentDB { get; set; } = new();

        public List<Appointment> AppointmentsDB { get; set; } = new List<Appointment>();

        public List<AppointmentView> Appointments { get; set; } = new List<AppointmentView>();

        public string FullName { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var appointmentsDB = (await AppointmentService.GetAll()).ToList();
            AppointmentsDB = appointmentsDB.Where(x => x.IsConfirmed.Equals(true)).ToList();

            Mapper.Map(AppointmentsDB, Appointments);
        }

        protected async Task HandleSearch(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey)) AppointmentsDB = (await AppointmentService.GetAll()).ToList();
            else AppointmentsDB = (await AppointmentService.Search(searchKey)).ToList();
            Mapper.Map(AppointmentsDB, Appointments);
        }

        protected async Task OnConfirmed(int id)
        {
            AppointmentDB = await AppointmentService.GetById(id);
            AppointmentDB.IsConfirmed = true;
            var appointment = await AppointmentService.UpdateEntity(AppointmentDB);
            if (appointment != null)
            {
                NavigationManager.NavigateTo("confirmedAppointments");
            }
        }


    }
}
