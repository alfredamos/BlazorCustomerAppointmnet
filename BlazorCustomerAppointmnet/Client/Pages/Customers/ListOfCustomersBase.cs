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
    public class ListOfCustomerSupportBase : ComponentBase
    {
        [Inject]
        public ICustomerService CustomerService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<Customer> CustomersDB { get; set; } = new();

        public List<CustomerView> Customers { get; set; } = new List<CustomerView>();

        public CustomerView Customer { get; set; } = new CustomerView();

        protected bool ShowFooter { get; set; } = false;

        protected bool HideFooter { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            CustomersDB = (await CustomerService.GetAll()).ToList();

            Mapper.Map(CustomersDB, Customers);
        }

        protected void UpdateCustomer(int customerId)
        {
            NavigationManager.NavigateTo($"/editCustomer/{customerId}");
        }

        protected void DeleteCustomer(int customerId)
        {
            NavigationManager.NavigateTo($"/deleteCustomer/{customerId}");
        }

        protected async Task HandleSearch(string searchKey)
        {
            CustomersDB = (await CustomerService.Search(searchKey)).ToList();
            Mapper.Map(CustomersDB, Customers);
        }

        protected void CreateCustomer()
        {
            NavigationManager.NavigateTo("/addCustomer");
        }

        protected void ShowFooterMethod()
        {
            ShowFooter = true;
            HideFooter = false;
            StateHasChanged();
        }

        protected void HideFooterMethod()
        {
            ShowFooter = false;
            HideFooter = true;
            StateHasChanged();
        }

    }
}
