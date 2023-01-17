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
    public class RecordComponentsController : Controller
    {
        private readonly ILogger<RecordComponentsController> _logger;
        private readonly ApplicationDbContext _dBcontext;
        public RecordComponentsController(ILogger<RecordComponentsController> logger, ApplicationDbContext dBcontext)
        {
            _logger = logger;
            _dBcontext = dBcontext;
        }
        [HttpGet("api/GetRecordComponents")]
        public async Task<List<Record_Components>> GetRecordComponents()
        {
            return await _dBcontext.Record_Components.ToListAsync();
        }
        [HttpPost("api/PostRecordComponents")]
        public IActionResult PostStaffCategories(Record_Components record_components)
        {
            _dBcontext.Record_Components.Add(record_components);
            return Ok();
        }
    }
}
