using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.ViewModels
{
    public class AppointmentView
    {
        public int AppointmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }       
        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set; } = false;

        public int CustomerID { get; set; }
        public CustomerView Customer { get; set; }

        public List<CustomerSupportAppointmentView> CustomerSupportAppointments { get; set; }

    }
}
