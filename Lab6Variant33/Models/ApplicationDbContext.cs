using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Appointment_Status_Codes> Appointment_Status_Codes{ get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Patient_Records> Patient_Records { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Record_Components> Record_Components { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Staff_Categories> Staff_Categories { get; set; }
        public DbSet<Staff_Patient_Associations> Staff_Patient_Associations { get; set; }
    }
}
