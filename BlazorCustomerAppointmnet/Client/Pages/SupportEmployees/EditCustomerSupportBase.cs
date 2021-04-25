using AutoMapper;
using BlazorCustomerAppointmnet.Client.Contracts;
using BlazorCustomerAppointmnet.Client.ViewModels;
using BlazorCustomerAppointmnet.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.Pages.SupportEmployees
{
    public class EditCustomerSupportBase : ComponentBase
    {
        [Inject]
        public ICustomerSupportService CustomerSupportService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public CustomerSupport CustomerSupportDB { get; set; } = new();

        public CustomerSupportView CustomerSupport { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            CustomerSupportDB = await CustomerSupportService.GetById(Id);
           
            Mapper.Map(CustomerSupportDB, CustomerSupport);            
        }

        protected async Task UpdateCustomerSupport()
        {          
            Mapper.Map(CustomerSupport, CustomerSupportDB);           

            var customer = await CustomerSupportService.UpdateEntity(CustomerSupportDB);

            if (customer != null)
            {       
                NavigationManager.NavigateTo("/customerSupportList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/customerSupportList");
        }

    }
}
