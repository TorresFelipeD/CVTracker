using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Company : BaseEntity
    {
        public string? Description { get; set; }
    }
}