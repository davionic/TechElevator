using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DetailViewModel
    {
        public Park Park { get; set; }
        public List<Weather> Weathers { get; set; } = new List<Weather>();
    }
}
