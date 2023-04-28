using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? PositionName { get; set; }
        public string? IdSkills { get; set; }
        public string? IdRequirements { get; set; }
        public string? IdEmploymentExchange { get; set; }
        public string? JobPostingURL { get; set; }
        public int IdStatus { get; set; }
    }
}