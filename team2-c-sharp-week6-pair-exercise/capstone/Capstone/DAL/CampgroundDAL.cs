using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAL;

namespace Capstone.DAL
{
    public class CampgroundsDAL
    {
        private const string SQL_Campground = "SELECT * FROM campground WHERE park_id = @park_id;";
        private const string SQL_OneCampgroundCost = "SELECT daily_fee FROM campground WHERE campground_id = @campgroundId;";
        private string connectionString;

        public CampgroundsDAL(string DatabaseConnectionString)
        {
            connectionString = DatabaseConnectionString;
        }

        public List<Campground> CampgroundInfo(int parkId)
        {
            List<Campground> campground = new List<Campground>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_Campground, conn);
                    cmd.Parameters.AddWithValue("@park_id", parkId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    

                    while (reader.Read())
                    {
                        Campground campy = new Campground();

                        campy.CampgroundId = Convert.ToInt32(reader["campground_id"]);
                        campy.ParkId = Convert.ToInt32(reader["park_id"]);
                        campy.Name = Convert.ToString(reader["name"]);
                        campy.OpenFromMonth = Convert.ToInt32(reader["open_from_mm"]);
                        campy.OpenToMonth = Convert.ToInt32(reader["open_to_mm"]);
                        campy.DailyFee = Convert.ToInt32(reader["daily_fee"]);
    
                        campground.Add(campy);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return campground;
        }

        public decimal GetDailyFeeFromOneCampground(int campgroundId)
        {
            decimal cost = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_OneCampgroundCost, conn);
                    cmd.Parameters.AddWithValue("@campgroundId", campgroundId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cost = Convert.ToDecimal(reader["daily_fee"]);
                        return cost;
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            return cost;
        }
    }
}
