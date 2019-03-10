using System;
using System.Collections.Generic;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL
{
   public class ReservationDAL
    {

        private const string SQL_ListAvailableCampsites = @"SELECT TOP 5 * FROM site s WHERE s.campground_id = @campground_id " +
            "AND s.site_id NOT IN(SELECT site_id from reservation WHERE (@requested_start < to_date AND @requested_start > from_date) " +
            "OR (@requested_end > from_date AND @requested_end < to_date) OR (@requested_start < from_date AND @requested_end > to_date));";
        private const string SQL_GetAllReservations = "SELECT * FROM reservation;";
        private const string SQL_ReserveSite = "INSERT INTO reservation (site_id, name, from_date, to_date, create_date) VALUES (@siteId, @name, @fromDate, @toDate, @createDate); " +
            "SELECT CAST(SCOPE_IDENTITY() as int);";

        int reservationId = 0;

        private string connectionString;

        public ReservationDAL(string DatabaseConnectionString)
        {
            connectionString = DatabaseConnectionString;
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
                    cmd.Parameters.AddWithValue("@campground_id", campgroundId);
                    cmd.Parameters.AddWithValue("@requested_start", requestedStart);
                    cmd.Parameters.AddWithValue("@requested_end", requestedEnd);

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
                        c.HasUtilities = Convert.ToBoolean(reader["max_rv_length"]);

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

        public int ReserveCampsite(int siteId, string name, DateTime fromDate, DateTime toDate, DateTime createDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_ReserveSite, conn);
                    cmd.Parameters.AddWithValue("@siteId", siteId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);
                    cmd.Parameters.AddWithValue("@createDate", createDate);

                    reservationId = (int)cmd.ExecuteScalar();

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return reservationId;
            
        }
    }
}
