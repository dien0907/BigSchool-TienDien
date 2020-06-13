using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigSchool.Models;
using BigSchool.ViewModels;
using Microsoft.AspNet.Identity;


namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public JsonResult LoadData()
        {
            var model = _dbContext.Courses;
            return Json(new
            {
                data = model,
                status = true
            }, JsonRequestBehavior.AllowGet) ;
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        //Post: /Courses/Create
        [Authorize]
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    viewModel.Categories = _dbContext.Categories.ToList();
                    return View("Create", viewModel);
                }
                var course = new Course
                {
                    LecturerId = User.Identity.GetUserId(),
                    DateTime = viewModel.GetDateTime(),
                    CategoryId = viewModel.Category,
                    Place = viewModel.Place
                };
                _dbContext.Courses.Add(course);
                _dbContext.SaveChanges();
                //TempData["message"] = "Save Successful";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                throw;       
            }
            
        }
    }
}