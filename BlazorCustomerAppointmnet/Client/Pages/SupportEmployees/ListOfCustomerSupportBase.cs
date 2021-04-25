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
    public class ListOfCustomerSupportBase : ComponentBase
    {
        [Inject]
        public ICustomerSupportService CustomerSupportService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<CustomerSupport> CustomerSupportsDB { get; set; } = new();

        public List<CustomerSupportView> CustomerSupports { get; set; } = new();

        public string FullName { get; set; }

        protected async override Task OnInitializedAsync()
        {
            CustomerSupportsDB = (await CustomerSupportService.GetAll()).ToList();

            Mapper.Map(CustomerSupportsDB, CustomerSupports);
        }

        protected async Task HandleSearch(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey)) CustomerSupportsDB = (await CustomerSupportService.GetAll()).ToList();
            else CustomerSupportsDB = (await CustomerSupportService.Search(searchKey)).ToList();
            Mapper.Map(CustomerSupportsDB, CustomerSupports);
        }

        protected void CreateCustomer()
        {
            NavigationManager.NavigateTo("/addCustomerSupport");
        }

        protected void UpdateCustomer(int customerSupportId)
        {
            NavigationManager.NavigateTo($"/editCustomerSupport/{customerSupportId}");
        }

        protected void DeleteCustomer(int customerSupportId)
        {
            NavigationManager.NavigateTo($"/deleteCustomerSupport/{customerSupportId}");
        }

        protected void DetailCustomer(int customerSupportId)
        {
            NavigationManager.NavigateTo($"/customerDetails/{customerSupportId}");
        }
    }
}
