using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class Staff_Patient_Associations
    {
        [Key]
        public int association_id { get; set; }
        public int patient_id { get; set; }
        public Patients patients { get; set; }
        public int staff_id { get; set; }
        public Staff staff { get; set; }
        public DateTime association_start_date { get; set; }
        public DateTime association_end_date { get; set; }
        public string association_details { get; set; }
    }
}
