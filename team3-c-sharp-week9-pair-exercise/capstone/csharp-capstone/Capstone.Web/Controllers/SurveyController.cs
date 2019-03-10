using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveySqlDal dal;

        public SurveyController(ISurveySqlDal surveyDal)
        {
            dal = surveyDal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            SurveyViewModel model = new SurveyViewModel
            {
                SurveyResults = dal.GetSurveys()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult NewSurvey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewSurvey(NewSurveyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                Survey survey = new Survey
                {
                    Code = model.Survey.Code,
                    Email = model.Survey.Email,
                    State = model.Survey.State,
                    ActivityLevel = model.Survey.ActivityLevel
                };
                dal.NewSurvey(survey);
                return RedirectToAction(nameof(Index));
            }           
        }
    }
}