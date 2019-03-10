using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumPostDAL _forumPostDal;

        private const string NewPostResultKey = nameof(NewPostResultKey);

        public ForumController(IForumPostDAL forumPostDal)
        {
            _forumPostDal = forumPostDal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ForumPostViewModel
            {
                Results = _forumPostDal.GetAllPosts()
            };

            if (TempData.ContainsKey(NewPostResultKey))
            {
                model.NewPostResult = TempData[NewPostResultKey] as string;
            }

            return View(model);
        }

        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(NewForumPostViewModel model)
        {
            var forumPost = new ForumPostModel
            {
                Subject = model.Subject,
                UserName = model.UserName,
                Message = model.Message
            };
            _forumPostDal.Create(forumPost);

            TempData[NewPostResultKey] = "Forum Post Successful!";

            return RedirectToAction(nameof(Index));
        }
    }
}