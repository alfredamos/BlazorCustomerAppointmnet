using AutoMapper;
using BlazorCustomerAppointmnet.Client.Contracts;
using BlazorCustomerAppointmnet.Client.ViewModels;
using BlazorCustomerAppointmnet.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.Pages.Customers
{
    public class AddCustomerSupportBase : ComponentBase
    {
        [Inject]
        public ICustomerService CustomerService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
   
        [Inject]
        public IMapper Mapper { get; set; }

        public Customer CustomerDB { get; set; } = new();

        public CustomerView Customer { get; set; } = new CustomerView();

        protected async Task CreateCustomer()
        {                          
            Mapper.Map(Customer, CustomerDB);
            
            var customer = await CustomerService.AddEntity(CustomerDB);

            if (customer != null)
            {            
                NavigationManager.NavigateTo("/customerList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/customerList");
        }

    }
}
