using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Collections.Generic;

namespace CapstoneTests.IntegrationTests
{
    [TestClass]
    public class SurveySqlDalTests
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

                cmd = new SqlCommand("DELETE FROM survey_result;", conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES('CVNP', 'bill@hotmail.com', 'Ohio', 'active');", conn);
                cmd.ExecuteScalar();
                cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES('CVNP', 'bill@hotmail.com', 'Ohio', 'active');", conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES('CVNP', 'bill@hotmail.com', 'Ohio', 'active');", conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("SELECT * FROM survey_result;", conn);
                cmd.ExecuteScalar();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetResponsesTest()
        {
            SurveySqlDal dal = new SurveySqlDal(connectionString);
            List<Survey> surveys = dal.GetSurveys();

            Assert.IsNotNull(surveys);
            Assert.AreEqual(3, surveys.Count);
        }

        [TestMethod]
        public void NewSurveyTest()
        {
            SurveySqlDal dal = new SurveySqlDal(connectionString);

            Survey survey = new Survey
            {
                Code = "CVNP",
                State = "Ohio",
                Email = "bob@email.com",
                ActivityLevel = "inactive"
            };

            dal.NewSurvey(survey);
            List<Survey> surveys = dal.GetSurveys();

            Assert.AreEqual(4, surveys.Count);
        }
    }
}
