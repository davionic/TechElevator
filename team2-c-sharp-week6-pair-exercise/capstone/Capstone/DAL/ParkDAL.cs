using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using System.Data.SqlClient;


namespace Capstone.DAL
{
    public class ParksDAL
    {
        private const string SQL_Parks = "SELECT * from park WHERE @park_id = park_id;";
        private const string SQL_ParkName = "SELECT park.park_id, park.name from park ORDER BY park.name;";
        private string connectionString;

        public ParksDAL(string DatabaseConnectionString)
        {
            connectionString = DatabaseConnectionString;
        }

        public List<Park> ListParkNames()
        {
                List<Park> parks = new List<Park>();
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand(SQL_ParkName, conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                        Park park = new Park();

                        park.Name = Convert.ToString(reader["name"]);
                        park.ParkId = Convert.ToInt32(reader["park_id"]);

                        parks.Add(park);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            return parks;
            
        }

        public Park FullParkInfo(int parkId)
        {
            Park park = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_Parks, conn);

                    cmd.Parameters.AddWithValue("@park_id", parkId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park.ParkId = Convert.ToInt32(reader["park_id"]);
                        park.Name = Convert.ToString(reader["name"]);
                        park.Location = Convert.ToString(reader["location"]);
                        park.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
                        park.Area = Convert.ToInt32(reader["area"]);
                        park.Visitors = Convert.ToInt32(reader["visitors"]);
                        park.Description = Convert.ToString(reader["description"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return park;
        }
    }
}
