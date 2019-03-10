using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienWeightModel
    {
        public string Planet { get; set; }
        public int EarthWeight { get; set; }
        
        public IList<AlienWeightModel> Results { get; set; }

    }

   
}