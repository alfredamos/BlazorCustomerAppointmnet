using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Shared.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }       
        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set; } = false;

        [ForeignKey("Appointment")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public List<CustomerSupportAppointment> CustomerSupportAppointments { get; set; }

    }
}
