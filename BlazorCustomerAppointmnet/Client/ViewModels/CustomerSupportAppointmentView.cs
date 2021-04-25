using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client.ViewModels
{
    public class CustomerSupportAppointmentView
    {
        public int AppointmentID { get; set; }
        public int CustomerSupportID { get; set; }
        public AppointmentView Appointment { get; set; }
        public CustomerSupportView CustomerSupport { get; set; }
    }
}
