using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class CalculatorsController : Controller
    {
        // INSTRUCTIONS
        // As a part of each exercise you will need to 
        // - develop a view for AlienAge, AlienWeight, and AlienTravel that displays a form to submit data
        // - create a new action to process the form submission (e.g. AlienAgeResult, AlienWeightResult, etc.)
        // - create a view that displays the submitted form result

        public ActionResult AlienAge()
        {
            return View();
        }


        public ActionResult AlienAgeResult(AlienAgeViewModel model)
        {
            return View(model);
        }

        public ActionResult AlienWeight()
        {
            return View();
        }


        public ActionResult AlienWeightResult(AlienWeightViewModel model)
        {
            return View(model);
        }

        public ActionResult AlienTravelTime()
        {
            return View();
        }


        public ActionResult AlienTravelTimeResult(AlienTravelTimeViewModel model)
        {
            return View(model);
        }


       
    }
}