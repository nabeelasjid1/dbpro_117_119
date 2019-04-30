﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SmartSchoolManagementSystem.CollectionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmartSchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        #region Initialization
        //Initialization Of Database Entities
        DB40Entities4 db = new DB40Entities4();
        //Initialization of User Managers for Adding Roles Based Users In database
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
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

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        #endregion

        #region Student Pages
        // GET: Student
        public ActionResult Index()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var DptRel = db.DepartmentStudentRelations.Where(c => c.StudentId == student.StudentId).FirstOrDefault();
            var PrtRel = db.ParentStudentRelations.Where(c => c.StudentId == student.StudentId).FirstOrDefault();
            var CompRel = db.StudentcomplaintRelations.Where(c => c.StudentId == student.StudentId).FirstOrDefault();
            var CourRel = db.StudentRegSubjectRelations.Where(c => c.StudentId == student.StudentId).FirstOrDefault();
            var EvntRel = db.StudentEventRelations.Where(c => c.StudentId == student.StudentId).FirstOrDefault();
            //var HstlRel = db.StudentHostelRelations.Where(c => c.StudentId == student.StudentId).FirstOrDefault();
            var collection = new CollectionOfAllViewModel
            {
                Department = db.Departments.Where(c => c.DepartmentId == DptRel.DepartmentId).SingleOrDefault(),
                Complaints = db.complaints.Where(c => c.complaintId == CompRel.complaintId).ToList(),
                Courses = db.Courses.Where(c => c.CourseId == CourRel.SubjectId).ToList(),
                Events = db.Events.Where(c => c.EventId == EvntRel.EventId).ToList(),
                News = db.News.ToList(),
                Notices = db.Notices.ToList()

            };
            return View(collection);
        }
        #endregion

        #region Complains Section
        // GET List Of Complaint
        public ActionResult CompliantsList()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var CompRel = db.StudentcomplaintRelations.Where(c => c.StudentId == student.StudentId).ToList();
            List<complaint> ComplaintsList = new List<complaint>();
            var complaints = db.complaints.ToList();
            foreach (var item in complaints)
            {
                foreach (var item1 in CompRel)
                {
                    if (item.complaintId == item1.complaintId)
                    {
                        ComplaintsList.Add(item);
                    }
                }

            }
            var model = ComplaintsList.Distinct();
            return View(model);
        }
        //GET Add Complaint
        public ActionResult AddComplaint()
        {
            return View();
        }
        //POST Add Complaint
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComplaint(complaint model)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            db.complaints.Add(model);
            var StudentCompliantRelation = new StudentcomplaintRelation
            {
                complaintId = model.complaintId,
                StudentId = student.StudentId
            };
            db.StudentcomplaintRelations.Add(StudentCompliantRelation);
            db.SaveChanges();
            return RedirectToAction("CompliantsList");
        }
        // GET: Delete Complaint
        public ActionResult DeleteComplaint(int id)
        {
            var model = db.complaints.Where(c => c.complaintId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Delete Complain
        [HttpPost]
        public ActionResult DeleteComplaint(int id, complaint col)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var complaint = db.complaints.Where(c => c.complaintId == id).SingleOrDefault();
            db.complaints.Remove(complaint);
            var StudentComplaintRelation = db.StudentcomplaintRelations.Where(c => c.complaintId == id && c.StudentId == student.StudentId).SingleOrDefault();
            db.StudentcomplaintRelations.Remove(StudentComplaintRelation);
            db.SaveChanges();
            return RedirectToAction("CompliantsList");
        }
        #endregion

        #region RegisterSubjects Section
        // GET List Of Course where Student is Registered
        public ActionResult CoursesList()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var Rel = db.StudentRegSubjectRelations.Where(c=> c.StudentId == student.StudentId).ToList();
            List<Course> coursesList = new List<Course>();
            var course = db.Courses.ToList();
            foreach (var item in course)
            {
                foreach (var item1 in Rel)
                {
                    if (item.CourseId == item1.SubjectId)
                    {
                        coursesList.Add(item);
                    }
                }
                
            }
            var model = coursesList.Distinct();
            return View(model);
        }
        // GET: Unenroll Course
        public ActionResult UnrollCourse(int id)
        {
            var model = db.Courses.Where(c => c.CourseId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Unenroll Course
        [HttpPost]
        public ActionResult UnrollCourse(int id, Course col)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var model = db.StudentRegSubjectRelations.Where(c => c.SubjectId == id && c.SubjectId == student.StudentId).SingleOrDefault();
            db.StudentRegSubjectRelations.Remove(model);
            db.SaveChanges();
            return RedirectToAction("CoursesList");
        }

        #endregion

        #region JoinedEvents Section
        // GET List Of Events where Student has Joined
        public ActionResult EventsList()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var Rel = db.StudentEventRelations.Where(c => c.StudentId == student.StudentId).ToList();
            List<Event> EventList = new List<Event>();
            var events = db.Events.ToList();
            foreach (var item in events)
            {
                foreach (var item1 in Rel)
                {
                    if (item.EventId == item1.EventId)
                    {
                        EventList.Add(item);
                    }
                }

            }
            var model = EventList.Distinct();
            return View(model);
        }
        // GET: Leave Event
        public ActionResult LeaveEvent(int id)
        {
            var model = db.Events.Where(c => c.EventId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Leave Event
        [HttpPost]
        public ActionResult LeaveEvent(int id, Course col)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var model = db.StudentEventRelations.Where(c => c.EventId == id && c.StudentId == student.StudentId).SingleOrDefault();
            db.StudentEventRelations.Remove(model);
            db.SaveChanges();
            return RedirectToAction("EventsList");
        }

        #endregion

        #region ManageAccount Section
        // GET: ManageAccount Student
        public ActionResult ManageAccount()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var std = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var collection = new StudentManageAccountViewModel
            {
                Student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault(),
                NewPassword = null,
                OldPassword = std.Password,
                ConfirmPassword = null,
                Parents = db.Parents.ToList(),
                Departments = db.Departments.ToList()
            };
            return View(collection);
        }

        //POST Add Parent
        // POST: ManageAccount Student
        [HttpPost]
        public ActionResult ManageAccount(StudentManageAccountViewModel model)
        {
            //var manager = new UserManager();
            var user = UserManager.FindById(User.Identity.GetUserId());
            var token = UserManager.GeneratePasswordResetToken(user.Id);
            UserManager.ResetPassword(user.Id, token, model.NewPassword);
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            student.FirstName = model.Student.FirstName;
            student.LastName = model.Student.LastName;
            student.UserName = model.Student.UserName;
            student.UserRole = "Student";
            student.EnrollmentDate = model.Student.EnrollmentDate;
            student.RegistrationNumber = model.Student.RegistrationNumber;
            student.Status = model.Student.Status;
            student.Password = model.NewPassword;
            student.Email = model.Student.Email;
            student.UserId = model.Student.UserId;;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Hostel Section
        // GET: All Hostels List
        public ActionResult HostelsList()
        {
            var model = db.Hostels.ToList();
            return View(model);
        }

        // GET: Apply For Hostel
        public ActionResult ApplyForHostel(int id)
        {
            var model = db.Hostels.Where(c=> c.HostelId == id).SingleOrDefault();
            return View(model);
        }
        // POST: Apply For Hostel
        [HttpPost]
        public ActionResult ApplyForHostel(int id, Hostel model)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var collection = db.Hostels.Where(c => c.HostelId == id).SingleOrDefault();
            var HostelRel = new StudentHostelRelation
            {
                HostelId = id,
                StudentId = student.StudentId,
            };
            db.StudentHostelRelations.Add(HostelRel);
            db.SaveChanges();
            return RedirectToAction("AppliedHostel");
        }

        // GET: Applied For Hostel
        public ActionResult AppliedHostel()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var HostelRel = db.StudentHostelRelations.Where(c => c.StudentId == student.StudentId).SingleOrDefault();
            var model = db.Hostels.Where(c => c.HostelId == HostelRel.HostelId).ToList();
            return View(model);
        }

        // GET: UnApply For Hostel
        public ActionResult UnApplyForHostel(int id)
        {
            var model = db.Hostels.Where(c => c.HostelId == id).SingleOrDefault();
            return View(model);
        }
        // POST: UnApply For Hostel
        [HttpPost]
        public ActionResult UnApplyForHostel(int id, Hostel model)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var hostel = db.Hostels.Where(c => c.HostelId == id).SingleOrDefault();
            var HostelRel = db.StudentHostelRelations.Where(c => c.HostelId == hostel.HostelId && c.StudentId == student.StudentId).SingleOrDefault();
            db.StudentHostelRelations.Remove(HostelRel);
            db.SaveChanges();
            return RedirectToAction("AppliedHostel");
        }
        #endregion

        #region Challans Section
        // GET List Of Challans of Student
        public ActionResult ChallansList()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var student = db.Students.Where(c => c.UserId == user.Id).SingleOrDefault();
            var Rel = db.StudentChalanRelations.Where(c => c.StudentId == student.StudentId).ToList();
            List<Chalan> challansList = new List<Chalan>();
            var chalans = db.Chalans.ToList();
            foreach (var item in chalans)
            {
                foreach (var item1 in Rel)
                {
                    if (item.ChalanId == item1.ChalanId)
                    {
                        challansList.Add(item);
                    }
                }

            }
            var model = challansList.Distinct();
            return View(model);
        }
        #endregion
    }
}
