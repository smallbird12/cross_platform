using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class Staff_Categories
    {
        [Key]
        public int staff_categories_code { get; set; }
        public string staff_category_description { get; set; }
        public List<Staff> staff { get; set; }
    }
}
