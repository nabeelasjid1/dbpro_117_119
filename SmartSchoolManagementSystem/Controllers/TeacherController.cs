using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SmartSchoolManagementSystem.CollectionViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSchoolManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        #region Initialization
        //Initialization Of Database Entities
        DB40Entities db = new DB40Entities();
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
        //Creating Path of the Image Being Uploaded
        public string uploadingfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {

                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                        //    ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please select a file'); </script>");
                path = "-1";
            }



            return path;
        }
        #endregion

        #region Teacher Pages
        // GET: Teacher
        [Authorize(Roles = "Teacher")]
        public ActionResult Index()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var teacher = db.Instructors.Where(c => c.UserId == user.Id).SingleOrDefault();
            var DptRel = db.DepartmentInstructorRelations.Where(c => c.InstructorId == teacher.InstructorId).SingleOrDefault();
            var department = db.Departments.Where(c => c.DepartmentId == DptRel.DepartmentId).SingleOrDefault();
            var Rel = db.InstructorCourseRelations.Where(c => c.InstructorId == teacher.InstructorId).ToList();
            var collection = new CollectionOfAllViewModel
            {
                Rel2 = Rel,
                Hostels = db.Hostels.ToList(),
                News = db.News.ToList(),
                Notices = db.Notices.ToList(),
                Department = department

            };

            return View(collection);
        }
        #endregion

        #region Manage Account Section

        // GET: ManageAccount Student
        [Authorize(Roles = "Teacher")]
        public ActionResult ManageAccount()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var teacher = db.Instructors.Where(c => c.UserId == user.Id).SingleOrDefault();
            var collection = new TeacherManageAccountViewModel
            {
                Teacher = db.Instructors.Where(c => c.UserId == user.Id).SingleOrDefault(),
                NewPassword = null,
                OldPassword = teacher.Password,
                ConfirmPassword = null
            };
            return View(collection);
        }
        // POST: ManageAccount Parent
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public ActionResult ManageAccount(TeacherManageAccountViewModel model, HttpPostedFileBase imgfile)
        {
            //var manager = new UserManager();
            var user = UserManager.FindById(User.Identity.GetUserId());
            var teacher = db.Instructors.Where(c => c.UserId == user.Id).SingleOrDefault();
            string path = uploadingfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";

            }
            else
            {
                var token = UserManager.GeneratePasswordResetToken(user.Id);
                UserManager.ResetPassword(user.Id, token, model.NewPassword);
                teacher.FirstName = model.Teacher.FirstName;
                teacher.LastName = model.Teacher.LastName;
                teacher.UserName = model.Teacher.UserName;
                teacher.UserRole = "Teacher";
                teacher.Contact = model.Teacher.Contact;
                teacher.Password = model.NewPassword;
                teacher.Email = model.Teacher.Email;
                teacher.UserId = model.Teacher.UserId;
                teacher.Detail = model.Teacher.Detail;
                teacher.Specialization = model.Teacher.Specialization;
                teacher.ImageUrl = model.Teacher.ImageUrl;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Profile Varification
        // GET: ManageAccount Student
        [Authorize(Roles = "Teacher")]
        public ActionResult ViewProfile()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var teacher = db.Instructors.Where(c => c.UserId == user.Id).SingleOrDefault();
            return View(teacher);
        }
        #endregion

        #region Mark Attendance
        // GET List Of  Allocated Subjects of Teacher
        [Authorize(Roles = "Teacher")]
        public ActionResult CoursesList()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var teacher = db.Instructors.Where(c => c.UserId == user.Id).SingleOrDefault();
            var Rel = db.InstructorCourseRelations.Where(c => c.InstructorId == teacher.InstructorId).ToList();
            List<Course> coursesList = new List<Course>();
            var course = db.Courses.ToList();
            foreach (var item in course)
            {
                foreach (var item1 in Rel)
                {
                    if (item.CourseId == item1.CourseId)
                    {
                        coursesList.Add(item);
                    }
                }

            }
            var model = coursesList;
            return View(model);
        }

        // GET List Of All Students Registered In Subject
        public ActionResult MarkAttendance(int id)
        {
            var subject = db.Courses.Where(c => c.CourseId == id).SingleOrDefault();
            var SubjectRel = db.StudentRegSubjectRelations.Where(c => c.SubjectId == subject.CourseId).ToList();
            List<Student> StudentsList = new List<Student>();
            var students = db.Students.ToList();
            foreach (var item in students)
            {
                foreach (var item1 in SubjectRel)
                {
                    if (item.StudentId == item1.StudentId)
                    {
                        StudentsList.Add(item);
                    }
                }

            }
            var model = new MarkAttendenceViewModel
            {
                Students = StudentsList,
                Lookups = db.Lookups.Where(c=> c.Category == "ATTENDANCE_STATUS").ToList(),
                Lookup = new Lookup(),
            };
            return View(model);
        }
        // GET List Of All Students Registered In Subject
        [HttpPost]
        public ActionResult MarkAttendance(int id,MarkAttendenceViewModel model)
        {
            var todayDate = DateTime.Now.Date;
            if (db.ClassAttendences.Any(c=> c.AttendanceDate == todayDate && c.CourseAttendences.Any(d=> d.CourseId == id)))
            {
                return RedirectToAction("CoursesList");
            }
            var ClassAttendence = new ClassAttendence
            {
                AttendanceDate = DateTime.Now.Date
            };
            var CourseAttendence = new CourseAttendence
            {
                AttendenceId = ClassAttendence.ClassAttendenceId,
                CourseId = id
            };
            db.CourseAttendences.Add(CourseAttendence);
            db.ClassAttendences.Add(ClassAttendence);
            for(int i = 0; i < model.Students.Count; i++)
            {
                Student Std = model.Students[i];
                Lookup lup = model.Lookups[i];
                var student = db.Students.Where(c => c.StudentId == Std.StudentId).SingleOrDefault();
                var status = db.Lookups.Where(c => c.LookupId == lup.LookupId).SingleOrDefault();
                var studentAttendance = new StudentAttendence
                {
                    StudentId = Std.StudentId,
                    AttendenceStatus = lup.LookupId,
                    AttendenceId = ClassAttendence.ClassAttendenceId
                };
                db.StudentAttendences.Add(studentAttendance);
            }
            db.SaveChanges();
            return RedirectToAction("CoursesList");
        }
        #endregion

        #region Upload Result
        // GET List Of  Allocated Subjects of Teacher
        [Authorize(Roles = "Teacher")]
        public ActionResult CoursesList1()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var teacher = db.Instructors.Where(c => c.UserId == user.Id).SingleOrDefault();
            var Rel = db.InstructorCourseRelations.Where(c => c.InstructorId == teacher.InstructorId).ToList();
            List<Course> coursesList = new List<Course>();
            var course = db.Courses.ToList();
            foreach (var item in course)
            {
                foreach (var item1 in Rel)
                {
                    if (item.CourseId == item1.CourseId)
                    {
                        coursesList.Add(item);
                    }
                }

            }
            var model = coursesList;
            return View(model);
        }

        // GET List Of All Students Registered In Subject
        [Authorize(Roles = "Teacher")]
        public ActionResult UploadResult(int id)
        {
            var subject = db.Courses.Where(c => c.CourseId == id).SingleOrDefault();
            var SubjectRel = db.StudentRegSubjectRelations.Where(c => c.SubjectId == id).ToList();
            List<Student> StudentsList = new List<Student>();
            var students = db.Students.ToList();
            foreach (var item in students)
            {
                foreach (var item1 in SubjectRel)
                {
                    if (item.StudentId == item1.StudentId)
                    {
                        StudentsList.Add(item);
                    }
                }

            }
            var model = new UploadResultViewModel
            {
                Students = StudentsList,
                StudentResult = new StudentResult(),
                Course = subject,
                Lookups = db.Lookups.Where(c => c.Category == "STUDENT_GRADE").ToList(),
                StudentResults = db.StudentResults.ToList()
            };
            return View(model);
        }
        // GET List Of All Students Registered In Subject
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public ActionResult UploadResult(int id, UploadResultViewModel model)
        {
            for (int i = 0; i < model.Students.Count; i++)
            {
                Student Std = model.Students[i];
                Lookup lup = model.Lookups[i];
                if (!db.StudentResults.Any(c=> c.StudentId == Std.StudentId && c.CourseId == id))
                {
                    var studentResult = new StudentResult
                    {
                        StudentId = Std.StudentId,
                        Grade = lup.LookupId,
                        CourseId = id
                    };
                    db.StudentResults.Add(studentResult);
                }
            }
            db.SaveChanges();
            return RedirectToAction("CoursesList1");
        }
        #endregion
    }
}
