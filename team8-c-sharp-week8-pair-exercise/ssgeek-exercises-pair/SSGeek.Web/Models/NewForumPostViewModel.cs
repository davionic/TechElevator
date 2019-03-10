using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class NewForumPostViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Subject must be at least 2 characters.")]
        public string Subject { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Username can be 20 characers max.")]
        public string UserName { get; set; }

        [Required]
        public string Message { get; set; }

        public string SuccessMessage { get; set; }
    }
}
