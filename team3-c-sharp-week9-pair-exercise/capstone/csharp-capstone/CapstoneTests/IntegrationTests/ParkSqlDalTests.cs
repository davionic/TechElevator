using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Collections.Generic;

namespace CapstoneTests.IntegrationTests
{
    [TestClass]
    public class ParkSqlDalTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();

                cmd = new SqlCommand("SELECT * FROM park;", conn);
                cmd.ExecuteScalar();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetParkTest()
        {
            ParkSqlDal dal = new ParkSqlDal(connectionString);
            Park park = dal.GetPark("CVNP");

            Assert.IsNotNull(park);
            Assert.AreEqual("Cuyahoga Valley National Park", park.Name);
            Assert.AreEqual(125, park.MilesOfTrail);
        }

        [TestMethod]
        public void GetParksTest()
        {
            ParkSqlDal dal = new ParkSqlDal(connectionString);
            List<Park> parks = dal.GetParks();

            Assert.IsNotNull(parks);
            Assert.AreEqual(10, parks.Count);
        }

        [TestMethod]
        public void GetForecastTest()
        {
            ParkSqlDal dal = new ParkSqlDal(connectionString);
            List<Weather> weathers = dal.GetForecast("CVNP");

            Assert.IsNotNull(weathers);
            Assert.AreEqual(5, weathers.Count);

        }
    }
}
