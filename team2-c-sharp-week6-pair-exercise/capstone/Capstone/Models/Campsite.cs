using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Campsite
    {
        public int SiteId { get; set; }
        public int CampgroundId { get; set; }
        public int SiteNumber { get; set; }
        public int MaxOccupancy { get; set; }
        public bool IsAccessible { get; set; }
        public int MaxRvLength { get; set; }
        public bool HasUtilities { get; set; }


        public override string ToString()
        {
            return "".PadRight(10) + SiteNumber.ToString().PadRight(10) + "|".PadRight(6) +  
                MaxOccupancy.ToString().PadRight(7) + "|".PadRight(5) +
                IsAccessible.ToString().PadRight(9) +  "|".PadRight(4) +
                MaxRvLength.ToString().PadRight(5) + "|".PadRight(5) +
                HasUtilities.ToString().PadRight(7) + "|".PadRight(1);
        }

        public decimal GetCost(DateTime startDate, DateTime endDate, decimal dailyFee, bool hasUtilities)
        {
            int totalDays = (endDate - startDate).Days;

            if (hasUtilities)
            {
                return (totalDays * (dailyFee + 20));
            }
            else
            {
                return totalDays * dailyFee;
            }
        }
    }
}
