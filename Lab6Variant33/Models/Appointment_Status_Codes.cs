using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class Appointment_Status_Codes
    {
        [Key]
        public int appointment_status_code { get; set; }
        public string appointment_status_description { get; set; }
        public List<Appointments> appointments { get; set; }
    }
}
