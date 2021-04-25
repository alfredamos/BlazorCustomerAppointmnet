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

namespace BlazorCustomerAppointmnet.Client.Pages.Customers
{
    public class DeleteCustomerSupportBase : ComponentBase
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

        protected ConfirmDelete DeleteConfirmation { get; set; }

        protected bool ShowFooter { get; set; } = false;

        protected bool HideFooter { get; set; } = true;

        public string NameOfCustomer { get; set; }

        protected async override Task OnInitializedAsync()
        {
            CustomerDB = await CustomerService.GetById(Id);

            Mapper.Map(CustomerDB, Customer);

            NameOfCustomer = Customer.FullName;
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task CustomerToDelete(bool deteConfirmed)
        {
            Mapper.Map(Customer, CustomerDB);

            if (deteConfirmed)
            {
                await CustomerService.DeleteEntity(Id);

            }
            NavigationManager.NavigateTo("/customerList");
            
        }

        protected void UpdateCustomer(int customerId)
        {

            NavigationManager.NavigateTo($"/editCustomer/{customerId}");

        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/customerList");
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
