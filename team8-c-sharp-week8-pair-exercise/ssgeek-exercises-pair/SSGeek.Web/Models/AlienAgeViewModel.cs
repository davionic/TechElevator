using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienAgeViewModel
    {
         
        [Display(Name = "Planet")]
        public string Planet { get; set; }

        [Display(Name = "EarthAge")]
        public decimal EarthAge { get; set; }


        public IList<AlienAgeModel> Results { get; set; }

        public static List<SelectListItem> Planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury" },
            new SelectListItem() { Text = "Venus" },
            new SelectListItem() { Text = "Mars" },
            new SelectListItem() { Text = "Jupiter" },
            new SelectListItem() { Text = "Saturn" },
            new SelectListItem() { Text = "Neptune" },
            new SelectListItem() { Text = "Uranus" }
        };
    }
}

