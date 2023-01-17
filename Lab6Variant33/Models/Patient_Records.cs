using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class Patient_Records
    {
        [Key]
        public int patient_record_id { get; set; }
        public int patient_id { get; set; }
        public Patients patients { get; set; }
        public int component_code { get; set; }
        public Record_Components components { get; set; }
        public int updated_by_staff_id { get; set; }
        public Staff staff { get; set; }
    }
}
