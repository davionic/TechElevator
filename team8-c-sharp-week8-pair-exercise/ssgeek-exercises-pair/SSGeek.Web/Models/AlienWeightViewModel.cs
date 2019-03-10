using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienWeightViewModel
    {
        [Display(Name = "Planet")]
        public string Planet { get; set; }

        [Display(Name = "EarthWeight")]
        public decimal EarthWeight { get; set; }


        public IList<AlienWeightModel> Results { get; set; }

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
