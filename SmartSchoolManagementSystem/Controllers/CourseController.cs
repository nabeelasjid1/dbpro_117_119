using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SmartSchoolManagementSystem.CollectionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSchoolManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        #region Initializations Section
        //Initialization of Database
        DB40Entities4 db = new DB40Entities4();
        //Initialization of User Managers for Adding Roles Based Users In database
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region Course Section
        // GET: All Courses Course
        public ActionResult Index()
        {
            var model = db.Courses.ToList();
            return View(model);
        }

        // GET: Course/Details/5
        public ActionResult CourseDetails(int id)
        {
            var collection = new CourseCollectionViewModel
            {
                Course = db.Courses.Where(c => c.CourseId == id).SingleOrDefault(),
                Relation = db.InstructorCourseRelations.Where(c => c.CourseId == id).SingleOrDefault(),
            };
            return View(collection);
        }
        #endregion

        #region CourseApply Section
        
        public ActionResult CourseApply(int id, Course model)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CourseApply(int id)
        {
            StudentRegSubjectRelation rel = new StudentRegSubjectRelation();
            var course = db.Courses.Where(c => c.CourseId == id).SingleOrDefault();
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            rel.StudentId = student.StudentId;
            rel.SubjectId = course.CourseId;
            db.StudentRegSubjectRelations.Add(rel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
