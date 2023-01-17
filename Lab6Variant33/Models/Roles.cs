using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class Roles
    {
        [Key]
        public int role_code { get; set; }
        public string role_description { get; set; }
        public List<Staff> staff { get; set; }
    }
}
