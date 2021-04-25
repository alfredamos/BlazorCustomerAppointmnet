using AutoMapper;
using BlazorCustomerAppointmnet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Server.Mappings
{
    public class Mapp : Profile
    {
        public Mapp()
        {
            CreateMap<Appointment, Appointment>();
            CreateMap<Customer, Customer>();
            CreateMap<CustomerSupport, CustomerSupport>();
            CreateMap<CustomerSupportAppointment, CustomerSupportAppointment>();
        }
    }
}
