using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSchoolManagementSystem.Controllers
{
    public class EventController : Controller
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

        #region Event Section
        // GET: List of All Events
        public ActionResult Index()
        {
            var model = db.Events.ToList();
            return View(model);
        }

        // GET: Event/Details/5
        public ActionResult EventDetails(int id)
        {
            var vent = db.Events.Where(c => c.EventId == id).SingleOrDefault();
            return View(vent);
        }
        #endregion

        #region EventApply Section
        public ActionResult EventApply(int id, Event model)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EventApply(int id)
        {
            StudentEventRelation rel = new StudentEventRelation();
            var vent = db.Events.Where(c => c.EventId == id).SingleOrDefault();
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            rel.StudentId = student.StudentId;
            rel.EventId = vent.EventId;
            db.StudentEventRelations.Add(rel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
