using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        private List<string> messages = new List<string>();

        public string ParkCode { get; set; }
        public int Day { get; set; }
        public decimal LowTemp { get; set; }
        public decimal HighTemp { get; set; }
        public string TempUnit { get; set; } = "F";
        public string Forecast { get; set; }
        public List<string> Messages
        {
            get
            {
                if (Forecast == "snow")
                {
                    messages.Add("Pack snowshoes!");
                }
                else if (Forecast == "rain")
                {
                    messages.Add("Pack rain gear & waterproof shoes!");
                }
                else if (Forecast == "thunderstorms")
                {
                    messages.Add("Seek shelter! Avoid hiking on exposed ridges!");
                }
                else if (Forecast == "sun")
                {
                    messages.Add("Pack Sunblock!");
                }

                if (HighTemp > 75)
                {
                    messages.Add("Bring an extra gallon of water!");
                }
                else if (LowTemp < 20)
                {
                    messages.Add("Wear lots of layers!");
                }

                if (HighTemp - LowTemp > 20)
                {
                    messages.Add("The temperature is topsy turvy!! " +
                        "Wear breathable layers.");
                }

                return messages;
            }
        }

        public int ConvertToCelsius(int temp, string tempUnit)
        {
            if (tempUnit == "F")
            {
                return (int)Math.Round((temp - 32) * 5 / 9.0);
            }
            return temp;
        }
    }
}
