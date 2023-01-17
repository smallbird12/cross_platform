using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class Staff
    {
        [Key]
        public int staff_id { get; set; }
        public int staff_categories_code { get; set; }
        public Staff_Categories staff_categories { get; set; }
        public int role_code { get; set; }
        public Roles roles { get; set; }
        public string staff_first_name { get; set; }
        public string staff_middle_name { get; set; }
        public string staff_last_name { get; set; }
        public string staff_qualifications { get; set; }
        public string staff_birth_date { get; set; }
        public string other_staff_details { get; set; }
        public List<Staff_Patient_Associations> staff_patient_associations { get; set; }
        public List<Patient_Records> patient_records { get; set; }
        public List<Appointments> appointments { get; set; }
    }
}
