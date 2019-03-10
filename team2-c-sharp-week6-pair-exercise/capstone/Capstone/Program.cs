using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using System.Data.SqlClient;
using Capstone;

namespace capstone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NationalParkReservationCLI cli = new NationalParkReservationCLI();
            cli.RunNationalParks();
        }
    }
}
