using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Campground
    {
        public int CampgroundId { get; set; }
        public int ParkId { get; set; }
        public string Name { get; set; }
        public int OpenFromMonth { get; set; }
        public int OpenToMonth { get; set; }
        public decimal DailyFee { get; set; }

        public override string ToString()
        {
            return Name.PadRight(30) + OpenFromMonth.ToString().PadRight(10) + OpenToMonth.ToString().PadRight(10) +
                DailyFee.ToString();
        }
    }
}
