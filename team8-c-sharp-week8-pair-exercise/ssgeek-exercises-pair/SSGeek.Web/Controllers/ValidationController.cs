using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class ValidationController : Controller
    {

        private const string ValidationConfirmationKey = nameof(ValidationConfirmationKey);

        [HttpGet]
        public IActionResult Index()
        {
            var model = new NewForumPostViewModel
            {
                SuccessMessage = TempData[ValidationConfirmationKey] as string
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(NewForumPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TempData[ValidationConfirmationKey] = "Validation was successful!";
            return RedirectToAction(nameof(Index));
        }
    }
}