using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienTravelTimeViewModel
    {
        [Display(Name = "Planet")]
        public string Planet { get; set; }

        [Display(Name = "TransportMode")]
        public string TransportMode { get; set; }

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

        public static List<SelectListItem> TransportationModes = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking", Value="walking" },
            new SelectListItem() { Text = "Car", Value = "car" },
            new SelectListItem() { Text = "Bullet Train", Value = "bullet train" },
            new SelectListItem() { Text = "Boeing 747", Value = "boeing 747" },
            new SelectListItem() { Text = "Concorde", Value = "concorde" }
        };
    }
}
