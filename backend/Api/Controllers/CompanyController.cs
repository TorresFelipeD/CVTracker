using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database.Context;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CVTrackerContext? _context;

        public CompanyController(CVTrackerContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_context == null)
                return StatusCode(404, new { Message = "Not Found Data" });
            else if(_context?.Companies == null)
                return StatusCode(404, new { Message = "Not Found Data in Companies" });
            else
                return Ok(_context?.Companies?.ToList());
        }
    }
}