using Lab6Variant33.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Variant33.Controllers
{
    public class StaffCategoriesController : Controller
    {
        private readonly ILogger<StaffCategoriesController> _logger;
        private readonly ApplicationDbContext _dBcontext;

        public StaffCategoriesController(ILogger<StaffCategoriesController> logger, ApplicationDbContext dBcontext)
        {
            _logger = logger;
            _dBcontext = dBcontext;
        }
        [HttpGet("api/GetStaffCategories")]
        public async Task<List<Staff_Categories>> GetStaffCategories()
        {
            return await _dBcontext.Staff_Categories.ToListAsync();
        }
        [HttpPost("api/PostStaffCategories")]
        public IActionResult PostStaffCategories(Staff_Categories staff_categories)
        {
            _dBcontext.Staff_Categories.Add(staff_categories);
            return Ok();
        }
    }
}
