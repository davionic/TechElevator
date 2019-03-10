using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Transactions;
using Capstone.DAL;
using System.Data.SqlClient;
using Capstone.Tests;
using Capstone.Models;


namespace Capstone.Tests.DAL
{
    [TestClass()]
    public class CampgroundDALTests
    {
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NationalParkReservation;Integrated Security=True;";

        [TestMethod()]
        public void GetCampgroundsTest()
        {
            CampgroundsDAL newCampgroundDAL = new CampgroundsDAL(connectionString);

            int parkId = 1;

            List<Campground> campgrounds = newCampgroundDAL.CampgroundInfo(parkId);

            Assert.IsNotNull(campgrounds);
        }
    }
}
