using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.DAL;


namespace Capstone.Tests.DAL
{
    [TestClass()]
    public class ReservationDALtests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NationalParkReservation;Integrated Security=True;";
        private int beginningReservations;
        private int reservations;

        [TestMethod]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();

                cmd = new SqlCommand("SELECT COUNT (*) FROM reservation", conn);
                beginningReservations = (int)cmd.ExecuteScalar();


                ReservationDAL reservationDAL = new ReservationDAL(connectionString);

                reservationDAL.ReserveCampsite(1, "Bears", new System.DateTime(2018,11,01), new System.DateTime(2018,11,10), new System.DateTime(2018,10,01));

                cmd = new SqlCommand("SELECT COUNT (*) FROM reservation", conn);
                reservations = (int)cmd.ExecuteScalar();

                Assert.AreEqual(beginningReservations + 1, reservations);
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }
    }
}
