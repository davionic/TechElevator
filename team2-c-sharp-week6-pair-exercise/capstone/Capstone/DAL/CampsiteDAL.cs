using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Capstone.DAL;



namespace Capstone.DAL
{
    public class CampsiteDAL
    {
        private string connectionString;
        private const string SQL_ListAvailableCampsites = @"SELECT TOP 5 * FROM site s WHERE s.campground_id = @campgroundId " +
            "AND s.site_id NOT IN(SELECT site_id from reservation WHERE (@requestedStart < to_date AND @requestedStart > from_date) " +
            "OR (@requestedEnd > from_date AND @requestedEnd < to_date) OR (@requestedStart < from_date AND @requestedEnd > to_date));";
        private const string SQL_GetCampsite = @"SELECT * FROM site s WHERE site_id = @siteId;";
        private const string SQL_GetCampsiteId = @"SELECT site_id FROM site WHERE campground_id = @campgroundId AND site_number = @siteNumber;";

        public CampsiteDAL(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public List<Campsite> AvailableCampsites(int campgroundId, DateTime requestedStart, DateTime requestedEnd)
        {
            List<Campsite> availableCampsites = new List<Campsite>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_ListAvailableCampsites, conn);
                    cmd.Parameters.AddWithValue("@campgroundId", campgroundId);
                    cmd.Parameters.AddWithValue("@requestedStart", requestedStart);
                    cmd.Parameters.AddWithValue("@requestedEnd", requestedEnd);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campsite c = new Campsite();
                        c.SiteId = Convert.ToInt32(reader["site_id"]);
                        c.CampgroundId = Convert.ToInt32(reader["campground_id"]);
                        c.SiteNumber = Convert.ToInt32(reader["site_number"]);
                        c.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
                        c.IsAccessible = Convert.ToBoolean(reader["accessible"]);
                        c.MaxRvLength = Convert.ToInt32(reader["max_rv_length"]);
                        c.HasUtilities = Convert.ToBoolean(reader["utilities"]);

                        availableCampsites.Add(c);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return availableCampsites;
        }

        public Campsite GetCampsite(int siteId)
        {
            Campsite c = new Campsite();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_ListAvailableCampsites, conn);
                    cmd.Parameters.AddWithValue("@siteId", siteId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        c.SiteId = Convert.ToInt32(reader["site_id"]);
                        c.CampgroundId = Convert.ToInt32(reader["campground_id"]);
                        c.SiteNumber = Convert.ToInt32(reader["site_number"]);
                        c.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
                        c.IsAccessible = Convert.ToBoolean(reader["accessible"]);
                        c.MaxRvLength = Convert.ToInt32(reader["max_rv_length"]);
                        c.HasUtilities = Convert.ToBoolean(reader["utilities"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return c;
        }

        public int GetCampsiteId(int campgroundId, int campsiteNumber)
        {
            int siteId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetCampsiteId, conn);
                    cmd.Parameters.AddWithValue("@campgroundId", campgroundId);
                    cmd.Parameters.AddWithValue("@siteNumber", campsiteNumber);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        siteId = Convert.ToInt32(reader["site_id"]);
                        return siteId;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return siteId;
        }
    }
}