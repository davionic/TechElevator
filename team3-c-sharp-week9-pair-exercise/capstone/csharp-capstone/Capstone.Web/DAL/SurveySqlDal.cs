using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySqlDal : ISurveySqlDal
    {
        private readonly string connectionString;

        public SurveySqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Survey> GetSurveys()
        {
            List<Survey> surveys = new List<Survey>();
            string sql = "SELECT * FROM survey_result;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Survey survey = new Survey
                        {
                            Id = Convert.ToInt32(reader["surveyId"]),
                            Code = Convert.ToString(reader["parkCode"]),
                            Email = Convert.ToString(reader["emailAddress"]),
                            State = Convert.ToString(reader["state"]),
                            ActivityLevel = Convert.ToString(reader["activityLevel"])
                        };
                        surveys.Add(survey);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return surveys;
        }

        public bool NewSurvey(Survey survey)
        {
            string sql = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@code, @email, @state, @level);";

            int rows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@code", survey.Code);
                    cmd.Parameters.AddWithValue("@email", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@level", survey.ActivityLevel);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return rows > 0;
        }
    }
}
