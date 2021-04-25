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

namespace BlazorCustomerAppointmnet.Client.Pages.SupportEmployees
{
    public class DeleteCustomerSupportBase : ComponentBase
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

        protected ConfirmDelete DeleteConfirmation { get; set; }

        public string NameOfCustomerSupport { get; set; }

        protected async override Task OnInitializedAsync()
        {
            CustomerSupportDB = await CustomerSupportService.GetById(Id);

            Mapper.Map(CustomerSupportDB, CustomerSupport);

            NameOfCustomerSupport = CustomerSupport.FullName;

            Console.WriteLine("Name of Support Employee : " + NameOfCustomerSupport);
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task CustomerSupportToDelete(bool deteConfirmed)
        {
            Mapper.Map(CustomerSupport, CustomerSupportDB);

            if (deteConfirmed)
            {
                await CustomerSupportService.DeleteEntity(Id);

            }
            NavigationManager.NavigateTo("/customerSupportList");
            
        }

        protected void UpdateCustomer(int customerSupportId)
        {

            NavigationManager.NavigateTo($"/editCustomerSupport/{customerSupportId}");

        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/customerSupportList");
        }

    }
}
