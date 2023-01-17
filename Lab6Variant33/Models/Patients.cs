using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class Patients
    {
        [Key]
        public int patient_id { get; set; }
        public bool comanaged_yn { get; set; }
        public int nhs_number { get; set; }
        public string gender { get; set; }
        public DateTime date_of_birth {get;set;}
        public string patient_name { get; set; }
        public string patient_address { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public string other_patient_details { get; set; }
        public List<Staff_Patient_Associations> staff_patient_associations { get; set; }
        public List<Patient_Records> patient_records { get; set; }
        public List<Appointments> appointments { get; set; }
    }
}
