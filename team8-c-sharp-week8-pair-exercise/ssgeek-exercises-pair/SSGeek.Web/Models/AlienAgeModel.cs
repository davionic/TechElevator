using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienAgeModel
    {
            
        public string Planet { get; set; }
        public int EarthAge { get; set; }

        public IList<AlienAgeModel> Results { get; set; }

    }


}
    

