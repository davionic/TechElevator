using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Capstone.DAL;

namespace Capstone.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreateDate { get; set; }


        public override string ToString()
        {
            return ReservationId.ToString().PadRight(30) + SiteId.ToString().PadRight(10) + Name.ToString().PadRight(10) + FromDate.ToString().PadRight(10) +
                ToDate.ToString().PadRight(10);
        }
       
        
    }
}