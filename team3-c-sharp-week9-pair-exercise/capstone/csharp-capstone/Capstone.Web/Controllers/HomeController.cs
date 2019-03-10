using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;
using Capstone.Web.Extensions;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkSqlDal dal;

        public HomeController(IParkSqlDal parkDal)
        {
            dal = parkDal;
        }

        public IActionResult Index()
        {
            ParkViewModel model = new ParkViewModel()
            {
                Parks = dal.GetParks()
            };
            if (HttpContext.Session.Get<string>("Temp_Unit") == null)
            {
                HttpContext.Session.Set("Temp_Unit", "F");
            }
            return View(model);
        }

        public IActionResult Detail(string parkCode)
        {
            DetailViewModel model = new DetailViewModel()
            {
                Park = dal.GetPark(parkCode),   
                Weathers = dal.GetForecast(parkCode)
            };
            string bosh = HttpContext.Session.Get<string>("Temp_Unit");
            if (bosh == "C")
            {
                foreach(Weather weather in model.Weathers)
                {
                    weather.HighTemp = ConvertToCelsius((int)weather.HighTemp);
                    weather.LowTemp = ConvertToCelsius((int)weather.LowTemp);
                    weather.TempUnit = "C";
                }
            }
            else if (bosh == "F")
            {
                foreach (Weather weather in model.Weathers)
                {
                    weather.TempUnit = "F";
                }
            }
            return View(model);
        }

        public IActionResult ChangeTempUnit(string tempUnit)
        {
            HttpContext.Session.Set("Temp_Unit", tempUnit);
            return RedirectToAction(nameof(Index));
        }

        public decimal ConvertToCelsius(int temp)
        {
            string tempUnit = HttpContext.Session.Get<string>("Temp_Unit");
            if (tempUnit == "C")
            {
                return (decimal)Math.Round((temp - 32) * 5 / 9.0);
            }
            return temp;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
