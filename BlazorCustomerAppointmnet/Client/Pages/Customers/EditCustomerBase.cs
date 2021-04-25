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
    public class EditCustomerSupportBase : ComponentBase
    {       
        [Inject]
        public ICustomerService CustomerService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Customer CustomerDB { get; set; } = new();

        public CustomerView Customer { get; set; } = new CustomerView();

        protected async override Task OnInitializedAsync()
        {
            CustomerDB = await CustomerService.GetById(Id);
           
            Mapper.Map(CustomerDB, Customer);            
        }

        protected async Task UpdateCustomer()
        {          
            Mapper.Map(Customer, CustomerDB);           

            var customer = await CustomerService.UpdateEntity(CustomerDB);

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
