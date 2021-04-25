using AutoMapper;
using BlazorCustomerAppointmnet.Client.ViewModels;
using BlazorCustomerAppointmnet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.Mapings
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Appointment, AppointmentView>().ReverseMap();
            CreateMap<Customer, CustomerView>().ReverseMap();
            CreateMap<CustomerSupport, CustomerSupportView>().ReverseMap();
            CreateMap<CustomerSupportAppointment, CustomerSupportAppointmentView>().ReverseMap();
        }
    }
}
