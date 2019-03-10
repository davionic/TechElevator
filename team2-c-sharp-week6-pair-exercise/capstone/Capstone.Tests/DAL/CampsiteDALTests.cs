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
    public class CampsiteDALTests
    {
            private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NationalParkReservation;Integrated Security=True;";

            [TestMethod()]
            public void GetCampsitesTest()
            {
            CampsiteDAL newCampsiteDAL = new CampsiteDAL(connectionString);
            int parkId = 1;
                List<Campsite> campsites = newCampsiteDAL.AvailableCampsites(parkId);

                Assert.IsNotNull(campsites);
            }
        
    }
}
