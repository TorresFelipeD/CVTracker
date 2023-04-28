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
    public class RequirementController : ControllerBase
    {
        private readonly CVTrackerContext _context;
        private readonly IConfiguration _configuration;
        public RequirementController(CVTrackerContext _context, IConfiguration _configuration)
        {
            this._context = _context;
            this._configuration = _configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context?.Requirements?.ToList().OrderBy(x => x.Id).ToList());
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
                    Requirement? row = _context?.Requirements?.Where(x => x.Id == id).SingleOrDefault();
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
        public IActionResult Post(Requirement Requirements)
        {
            try
            {
                _context?.Requirements?.Add(Requirements);
                _context?.SaveChanges();
                dynamic jsonObj = new
                {
                    Message = "Record created successfully",
                    Record = Requirements
                };
                return Ok(JsonConvert.SerializeObject(jsonObj, Formatting.Indented));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { MessageError = $"Error: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Requirement Requirements)
        {
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    Requirement? row = _context?.Requirements?.Where(x => x.Id == id).SingleOrDefault();
                    if (row != null)
                    {
                        row.Name = Requirements.Name;

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
                    Requirement? row = _context?.Requirements?.Where(x => x.Id == id).SingleOrDefault();
                    if (row != null)
                    {
                        _context?.Requirements?.Remove(row);
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