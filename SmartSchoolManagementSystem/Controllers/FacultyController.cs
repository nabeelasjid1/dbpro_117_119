using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSchoolManagementSystem.Controllers
{
    public class FacultyController : Controller
    {
        #region Initializations Section
        //Initialization of Database
        DB40Entities db = new DB40Entities();
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

        #region Faculty Section
        // GET: Faculty
        public ActionResult Index()
        {
            var model = db.Instructors.ToList();
            return View(model );
        }

        // GET: Faculty/Details/5
        public ActionResult FacultyDetails(int id)
        {
            var model = db.Instructors.Where(c=> c.InstructorId ==id).SingleOrDefault();
            return View(model);
        }
        #endregion
    }
}
