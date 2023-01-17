using Lab6Variant33.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ILogger<AppointmentsController> _logger;
        private readonly ApplicationDbContext _dBcontext;
        public AppointmentsController(ILogger<AppointmentsController> logger, ApplicationDbContext dBcontext)
        {
            _logger = logger;
            _dBcontext = dBcontext;
        }
        [HttpGet("api/GetAppointmentsByDateTime")]
        public async Task<List<Appointments>> GetAppointmentsByDateTime(DateTime dateTime)
        {
            return await _dBcontext.Appointments
                .Where(a => a.appointment_datetime == dateTime)
                .Include(a => a.appointment_status_codes)
                .Include(a => a.patients)
                .Include(a => a.staff)
                .ToListAsync();
        }
        [HttpPost("api/GetAppointmentsByAppointmentIds")]
        public async Task<List<Appointments>> GetAppointmentsByDateTime(int[] appointmentIds)
        {
            return await _dBcontext.Appointments
                .Where(a => appointmentIds.Contains(a.appointment_id))
                .Include(a => a.appointment_status_codes)
                .Include(a => a.patients)
                .Include(a => a.staff)
                .ToListAsync();
        }
        [HttpGet("api/GetFirstAppointments")]
        public async Task<Appointments> GetFirstAppointments(DateTime dateTime)
        {
            return await _dBcontext.Appointments
                .Include(a => a.appointment_status_codes)
                .Include(a => a.patients)
                .Include(a => a.staff)
                .FirstOrDefaultAsync();
        }
        [HttpGet("api/GetLastAppointments")]
        public async Task<Appointments> GetLastAppointments(DateTime dateTime)
        {
            return await _dBcontext.Appointments
                .Include(a => a.appointment_status_codes)
                .Include(a => a.patients)
                .Include(a => a.staff)
                .LastOrDefaultAsync();
        }
    }
}
