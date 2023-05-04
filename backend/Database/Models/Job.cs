using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Job
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdCompany { get; set; }
        [Required]
        public string? PositionName { get; set; }
        [Required]
        public string? IdSkills { get; set; }
        [Required]
        public string? IdRequirements { get; set; }
        [Required]
        public int IdEmploymentExchange { get; set; }
        [Required]
        public string? JobPostingURL { get; set; }
        [Required]
        public int IdStatus { get; set; }
    }
}