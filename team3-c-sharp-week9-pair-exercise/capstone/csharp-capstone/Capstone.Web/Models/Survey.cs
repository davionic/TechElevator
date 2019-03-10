using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ActivityLevel { get; set; }
    }
}
