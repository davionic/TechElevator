using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkSqlDal : IParkSqlDal
    {
        private readonly string connectionString;

        public ParkSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Park GetPark(string parkCode)
        {
            Park park = new Park();
            string sql = "SELECT * FROM park WHERE parkCode = @parkCode;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park.Code = Convert.ToString(reader["parkCode"]);
                        park.Name = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        park.QuotedPerson = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.Description = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToDecimal(reader["entryFee"]);
                        park.NumberOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return park;
        }

        public List<Park> GetParks()
        {
            List<Park> parks = new List<Park>();
            string sql = "SELECT * FROM park;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Park park = new Park
                        {
                            Code = Convert.ToString(reader["parkCode"]),
                            Name = Convert.ToString(reader["parkName"]),
                            State = Convert.ToString(reader["state"]),
                            Acreage = Convert.ToInt32(reader["acreage"]),
                            Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                            MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]),
                            NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                            Climate = Convert.ToString(reader["climate"]),
                            YearFounded = Convert.ToInt32(reader["yearFounded"]),
                            AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]),
                            Quote = Convert.ToString(reader["inspirationalQuote"]),
                            QuotedPerson = Convert.ToString(reader["inspirationalQuoteSource"]),
                            Description = Convert.ToString(reader["parkDescription"]),
                            EntryFee = Convert.ToDecimal(reader["entryFee"]),
                            NumberOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
                        };
                        parks.Add(park);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return parks;
        }

        public List<Weather> GetForecast(string parkCode)
        {
            List<Weather> weathers = new List<Weather>();
            string sql = "SELECT * FROM weather WHERE parkCode = @parkCode;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Weather weather = new Weather
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            Day = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            LowTemp = Convert.ToInt32(reader["low"]),
                            HighTemp = Convert.ToInt32(reader["high"]),
                            Forecast = Convert.ToString(reader["forecast"])
                        };
                        weathers.Add(weather);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return weathers;
        }
    }
}
