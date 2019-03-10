using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SSGeek.Web.Models
{
    public class AlienTravelTimeModel
    {

        public string Planet { get; set; }
        public string TransportMode { get; set; }
        public int EarthAge { get; set; }

        public IList<AlienTravelTimeModel> Results { get; set; }

    }
}
