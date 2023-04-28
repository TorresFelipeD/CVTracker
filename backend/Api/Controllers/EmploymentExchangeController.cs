using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using Database.Models;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmploymentExchangeController : ControllerBase
    {
        private readonly CVTrackerContext _context;
        private readonly IConfiguration _configuration;
        public EmploymentExchangeController(CVTrackerContext _context, IConfiguration _configuration)
        {
            this._context = _context;
            this._configuration = _configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context?.EmploymentExchanges?.ToList().OrderBy(x => x.Id).ToList());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { MessageError = $"Error: {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    EmploymentExchange? row = _context?.EmploymentExchanges?.Where(x => x.Id == id).SingleOrDefault();
                    if (row != null)
                        return Ok(row);
                    else
                        return NotFound($"Record with Id:{id} Not Found");
                }
                else
                    return BadRequest($"Field Id is required");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { MessageError = $"Error: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult Post(EmploymentExchange EmploymentExchanges)
        {
            try
            {
                _context?.EmploymentExchanges?.Add(EmploymentExchanges);
                _context?.SaveChanges();
                dynamic jsonObj = new
                {
                    Message = "Record created successfully",
                    Record = EmploymentExchanges
                };
                return Ok(JsonConvert.SerializeObject(jsonObj, Formatting.Indented));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { MessageError = $"Error: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EmploymentExchange EmploymentExchanges)
        {
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    EmploymentExchange? row = _context?.EmploymentExchanges?.Where(x => x.Id == id).SingleOrDefault();
                    if (row != null)
                    {
                        row.Name = EmploymentExchanges.Name;

                        _context.Entry(row).State = EntityState.Modified;
                        _context.SaveChanges();

                        dynamic jsonObj = new
                        {
                            Message = "Record updated successfully",
                            Record = row
                        };
                        return Ok(JsonConvert.SerializeObject(jsonObj, Formatting.Indented));
                    }
                    else
                        return NotFound($"Record with Id:{id} Not Found");
                }
                else
                    return BadRequest($"Field Id is required");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { MessageError = $"Error: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    EmploymentExchange? row = _context?.EmploymentExchanges?.Where(x => x.Id == id).SingleOrDefault();
                    if (row != null)
                    {
                        _context?.EmploymentExchanges?.Remove(row);
                        _context.SaveChanges();

                        dynamic jsonObj = new
                        {
                            Message = "Record deleted successfully",
                            Record = row
                        };
                        return Ok(JsonConvert.SerializeObject(jsonObj, Formatting.Indented));
                    }
                    else
                        return NotFound($"Record with Id:{id} Not Found");
                }
                else
                    return BadRequest($"Field Id is required");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { MessageError = $"Error: {ex.Message}" });
            }
        }
    }
}