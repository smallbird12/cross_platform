using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class Record_Components
    {
        [Key]
        public int component_code { get; set; }
        public string component_description { get; set; }
        public List<Patient_Records> patient_records { get; set; }
    }
}
