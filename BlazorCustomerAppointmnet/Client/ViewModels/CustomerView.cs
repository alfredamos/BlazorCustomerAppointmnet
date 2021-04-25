using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.ViewModels
{
    public class CustomerView
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoPath { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName 
        { 
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
