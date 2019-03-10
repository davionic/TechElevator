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
    public class ParkDALtests
    {
            private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NationalParkReservation;Integrated Security=True;";

            [TestMethod()]
            public void GetParkNames()
            {
                ParksDAL parkNamesDAL = new ParksDAL(connectionString);
                List<Park> parks = parkNamesDAL.ListParkNames();

                Assert.IsNotNull(parks);
            }

        [TestMethod()]
        public void GetParkInfoTest()
        {
            ParksDAL parkInfoDAL = new ParksDAL(connectionString);
            int parkId = 1;
            Park parks = parkInfoDAL.FullParkInfo(parkId);

            Assert.IsNotNull(parks.Location);
            Assert.IsNotNull(parks.EstablishDate);
            Assert.IsNotNull(parks.Area);
            Assert.IsNotNull(parks.Visitors);
            Assert.IsNotNull(parks.Description);
        }
    }  
}
