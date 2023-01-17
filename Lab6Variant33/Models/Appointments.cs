using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class Appointments
    {
        [Key]
        public int appointment_id { get; set; }
        public int appointment_status_code { get; set; }
        public Appointment_Status_Codes appointment_status_codes { get; set; }
        public int patient_id { get; set; }
        public Patients patients { get; set; }
        public int staff_id { get; set; }
        public Staff staff { get; set; }
        public DateTime appointment_datetime { get; set; }
        public DateTime appointment_end_datetime { get; set; }
        public string appointment_details { get; set; }
    }
}
