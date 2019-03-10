using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class NewSurveyViewModel
    {
        public Survey Survey { get; set; } = new Survey();

        public static List<SelectListItem> Parks = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Cuyahoga Valley National Park", Value = "CVNP" },
            new SelectListItem() { Text = "Everglades National Park", Value = "ENP" },
            new SelectListItem() { Text = "Glacier National Park", Value = "GNP" },
            new SelectListItem() { Text = "Grand Canyon National Park", Value = "GCNP" },
            new SelectListItem() { Text = "Grand Teton National Park", Value = "GTNP" },
            new SelectListItem() { Text = "Great Smokey Mountain National Park", Value = "GSMNP" },
            new SelectListItem() { Text = "Mount Ranier National Park", Value = "MRNP" },
            new SelectListItem() { Text = "Rocky Mountain National Park", Value = "RMNP" },
            new SelectListItem() { Text = "Yellowstone National Park", Value = "YNP" },
            new SelectListItem() { Text = "Yosemite National Park", Value = "YNP2" }
        };

        public static List<SelectListItem> Levels = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Inactive" },
            new SelectListItem() { Text = "Sedentary" },
            new SelectListItem() { Text = "Active" },
            new SelectListItem() { Text = "Extremely Active" }
        };
    }
}
