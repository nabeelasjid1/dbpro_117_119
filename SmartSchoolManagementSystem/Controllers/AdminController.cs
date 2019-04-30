using Microsoft.AspNet.Identity.Owin;
using SmartSchoolManagementSystem.CollectionViewModel;
using SmartSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmartSchoolManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        #region Initialization
        //Initialization Of Database Entities
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

        #region Admin Pages
        //Index Having Statics of All Entities
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var collection = new CollectionOfAllViewModel
            {
                Departments = db.Departments.ToList(),
                Instructors = db.Instructors.ToList(),
                Parents = db.Parents.ToList(),
                Students = db.Students.ToList(),
                News = db.News.ToList(),
                Courses = db.Courses.ToList(),
                Events = db.Events.ToList(),
                Notices = db.Notices.ToList(),
                Hostels = db.Hostels.ToList()
            };
            return View(collection);
        }
        #endregion

        #region Department Section
        // GET List Of Departments
        public ActionResult DepartmentList()
        {
            var model = db.Departments.ToList();
            return View(model);
        }

        //GET Add Department
        public ActionResult AddDepartment()
        {
            return View();
        }
        //POST Add Department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(Department model)
        {
            db.Departments.Add(model);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
        // GET: Edit Department
        public ActionResult Edit(int id)
        {
            var model = db.Departments.Where(c => c.DepartmentId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Edit Department
        [HttpPost]
        public ActionResult Edit(int id, DepartmentViewModel col)
        {
            var model = db.Departments.Where(c => c.DepartmentId == id).SingleOrDefault();
            model.Name = col.Name;
            model.Description = col.Description;
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        // GET: Delete Department
        public ActionResult Delete(int id)
        {
            var model = db.Departments.Where(c => c.DepartmentId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Delete Department
        [HttpPost]
        public ActionResult Delete(int id, DepartmentViewModel col)
        {
            var model = db.Departments.Where(c => c.DepartmentId == id).SingleOrDefault();
            db.Departments.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
        #endregion

        #region Notice Section
        // GET List Of Notice
        public ActionResult NoticesList()
        {
            var model = db.Notices.ToList();
            return View(model);
        }
        //GET Add Notice
        public ActionResult AddNotice()
        {
            return View();
        }
        //POST Add Notice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNotice(Notice model)
        {
            db.Notices.Add(model);
            db.SaveChanges();
            return RedirectToAction("NoticesList");
        }
        // GET: Edit Notice
        public ActionResult EditNotice(int id)
        {
            var model = db.Notices.Where(c => c.NoticeId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Edit Notice
        [HttpPost]
        public ActionResult EditNotice(int id, NoticeViewModel col)
        {
            var model = db.Notices.Where(c => c.NoticeId == id).SingleOrDefault();
            model.Date = col.Date;
            model.Description = col.Description;
            db.SaveChanges();
            return RedirectToAction("NoticesList");
        }
        // GET: Delete Notice
        public ActionResult DeleteNotice(int id)
        {
            var model = db.Notices.Where(c => c.NoticeId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Delete Notice
        [HttpPost]
        public ActionResult DeleteNotice(int id, NoticeViewModel col)
        {
            var model = db.Notices.Where(c => c.NoticeId == id).SingleOrDefault();
            db.Notices.Remove(model);
            db.SaveChanges();
            return RedirectToAction("NoticesList");
        }
        #endregion

        #region Hostel Section
        // GET List Of Hostel
        public ActionResult HostelsList()
        {
            var model = db.Hostels.ToList();
            return View(model);
        }
        //GET Add Hostel
        public ActionResult AddHostel()
        {
            return View();
        }
        //POST Add Hostel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHostel(Hostel model)
        {
            db.Hostels.Add(model);
            db.SaveChanges();
            return RedirectToAction("HostelsList");
        }
        // GET: Edit Hostel
        public ActionResult EditHostel(int id)
        {
            var model = db.Hostels.Where(c => c.HostelId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Edit Hostel
        [HttpPost]
        public ActionResult EditHostel(int id, Hostel col)
        {
            var model = db.Hostels.Where(c => c.HostelId == id).SingleOrDefault();
            model.Name = col.Name;
            model.Capacity = col.Capacity;
            model.Description = col.Description;
            db.SaveChanges();
            return RedirectToAction("HostelsList");
        }
        // GET: Delete Hostel
        public ActionResult DeleteHostel(int id)
        {
            var model = db.Hostels.Where(c => c.HostelId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Delete Hostel
        [HttpPost]
        public ActionResult DeleteHostel(int id, Hostel col)
        {
            var model = db.Hostels.Where(c => c.HostelId == id).SingleOrDefault();
            db.Hostels.Remove(model);
            db.SaveChanges();
            return RedirectToAction("HostelsList");
        }
        #endregion

        #region Parent Section

        // GET: Delete Parent
        public ActionResult DeleteParent(string id)
        {
            var collection = new ParentCollectionViewModel
            {
                Parent = db.Parents.Where(c => c.UserId == id).SingleOrDefault()
            };
            return View(collection);
        }

        // POST: Delete Parent
        [HttpPost]
        public ActionResult DeleteParent(string id, ParentCollectionViewModel col)
        {
            var parent = db.Parents.Where(c => c.UserId == id).SingleOrDefault();
            db.Parents.Remove(parent);
            var user = db.AspNetUsers.Where(c => c.Id == id).SingleOrDefault();
            db.AspNetUsers.Remove(user);
            db.SaveChanges();
            return RedirectToAction("ParentsList");
        }
        // GET: Edit Parent
        public ActionResult EditParent(int id)
        {
            var collection = new ParentCollectionViewModel
            {
                Parent = db.Parents.Where(c => c.ParentId == id).SingleOrDefault()
            };
            return View(collection);
        }

        // POST: Edit Parent
        [HttpPost]
        public ActionResult EditParent(int id, ParentCollectionViewModel model)
        {
            var parent = db.Parents.Where(c => c.ParentId == id).SingleOrDefault();
            parent.FirstName = model.Parent.FirstName;
            parent.LastName = model.Parent.LastName;
            parent.UserName = model.Parent.UserName;
            parent.UserRole = "Parent";
            parent.Password = model.Parent.Password;
            parent.Email = model.Parent.Email;
            parent.Contact = model.Parent.Contact;
            parent.UserId = model.Parent.UserId;
            var user = db.AspNetUsers.Single(c => c.Id == model.Parent.UserId);
            user.Email = model.Parent.Email;
            user.UserName = model.Parent.UserName;
            user.UserRole = "Parent";
            user.Id = model.Parent.UserId;
            db.SaveChanges();
            return RedirectToAction("ParentsList");
        }

        // GET List Of Parent
        public ActionResult ParentsList()
        {
            var model = db.Parents.ToList();
            return View(model);
        }
        //GET Add Parent
        public ActionResult AddParent()
        {
            var collection = new ParentCollectionViewModel
            {
                ApplicationUser = new RegisterViewModel(),
                Parent = new Parent(),
            };
            return View(collection);
        }
        //POST Add Parent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddParent(ParentCollectionViewModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.ApplicationUser.UserName,
                Email = model.ApplicationUser.Email,
                UserRole = "Parent",
            };
            var result = await UserManager.CreateAsync(user, model.ApplicationUser.Password).ConfigureAwait(false);
            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "Parent").ConfigureAwait(false);
                var parent = new Parent
                {
                    FirstName = model.Parent.FirstName,
                    LastName = model.Parent.LastName,
                    Email = model.ApplicationUser.Email,
                    Contact = model.Parent.Contact,
                    UserName = model.ApplicationUser.UserName,
                    Password = model.ApplicationUser.Password,
                    UserRole = "Parent",
                    UserId = user.Id
                };
                db.Parents.Add(parent);
                db.SaveChanges();
                return RedirectToAction("ParentsList");
            }

            return HttpNotFound();

        }
        #endregion

        #region Student Section

        // GET: Delete Student
        public ActionResult DeleteStudent(string id, int idd)
        {
            var collection = new StudentCollectionViewModel
            {
                Student = db.Students.Where(c => c.UserId == id).SingleOrDefault(),
                Student1 = db.Students.Where(c => c.StudentId == idd).SingleOrDefault()
            };
            return View(collection);
        }

        // POST: Delete Student
        [HttpPost]
        public ActionResult DeleteStudent(string id,int idd, StudentCollectionViewModel col)
        {
            var student = db.Students.Where(c => c.UserId == id).SingleOrDefault();
            db.Students.Remove(student);
            var user = db.AspNetUsers.Where(c => c.Id == id).SingleOrDefault();
            db.AspNetUsers.Remove(user);
            var parentRelation = db.ParentStudentRelations.Where(c => c.StudentId == idd).SingleOrDefault();
            db.ParentStudentRelations.Remove(parentRelation);
            var deprtmentRelation = db.DepartmentStudentRelations.Where(c => c.StudentId == idd).SingleOrDefault();
            db.DepartmentStudentRelations.Remove(deprtmentRelation);
            db.SaveChanges();
            return RedirectToAction("StudentsList");
        }
        // GET: Edit Student
        public ActionResult EditStudent(int id)
        {
            var collection = new StudentCollectionViewModel
            {
                Student = db.Students.Where(c => c.StudentId == id).SingleOrDefault(),
                Parents = db.Parents.ToList(),
                Departments = db.Departments.ToList()
            };
            return View(collection);
        }

        // POST: Edit Student
        [HttpPost]
        public ActionResult EditStudent(int id, StudentCollectionViewModel model)
        {
            var student = db.Students.Where(c => c.StudentId == id).SingleOrDefault();
            student.FirstName = model.Student.FirstName;
            student.LastName = model.Student.LastName;
            student.UserName = model.Student.UserName;
            student.UserRole = "Student";
            student.EnrollmentDate = model.Student.EnrollmentDate;
            student.RegistrationNumber = model.Student.RegistrationNumber;
            student.Status = model.Student.Status;
            student.Password = model.Student.Password;
            student.Email = model.Student.Email;
            student.UserId = model.Student.UserId;
            var user = db.AspNetUsers.Single(c => c.Id == model.Student.UserId);
            user.Email = model.Student.Email;
            user.UserName = model.Student.UserName;
            user.UserRole = "Student";
            user.Id = model.Student.UserId;
            db.SaveChanges();
            return RedirectToAction("StudentsList");
        }

        // GET List Of Student
        public ActionResult StudentsList()
        {
            var collection = db.Students.ToList();
            return View(collection);
        }
        //GET Add Student
        [HttpGet]
        public ActionResult AddStudent()
        {
            var collection = new StudentCollectionViewModel
            {
                ApplicationUser = new RegisterViewModel(),
                Student = new Student(),
                Parents = db.Parents.ToList(),
                Departments = db.Departments.ToList()
            };
            return View(collection);
        }
        //POST Add Student
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddStudent(StudentCollectionViewModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.ApplicationUser.UserName,
                Email = model.ApplicationUser.Email,
                UserRole = "Student",
            };
            var result = await UserManager.CreateAsync(user, model.ApplicationUser.Password).ConfigureAwait(false);
            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "Student").ConfigureAwait(false);
                var parent = db.Parents.Where(c => c.ParentId == model.ParentId).SingleOrDefault();
                var depart = db.Departments.Where(c => c.DepartmentId == model.DepartmentId).SingleOrDefault();
                var student = new Student
                {
                    FirstName = model.Student.FirstName,
                    LastName = model.Student.LastName,
                    RegistrationNumber = model.Student.RegistrationNumber,
                    Status = model.Student.Status,
                    EnrollmentDate = DateTime.Now,
                    Email = model.ApplicationUser.Email,
                    UserName = model.ApplicationUser.UserName,
                    Password = model.ApplicationUser.Password,
                    UserRole = "Student",
                    UserId = user.Id
                };
                var relation = new ParentStudentRelation
                {
                    StudentId = student.StudentId,
                    ParentId = parent.ParentId
                };
                var depRelation = new DepartmentStudentRelation
                {
                    StudentId = student.StudentId,
                    DepartmentId = depart.DepartmentId
                };
                db.DepartmentStudentRelations.Add(depRelation);
                db.ParentStudentRelations.Add(relation);
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("StudentsList");
            }

            return HttpNotFound();

        }
        #endregion

        #region News Section
        
        // GET List Of News
        public ActionResult NewsList()
        {
            var model = db.News.ToList();
            return View(model);
        }
        //GET Add News
        [HttpGet]
        public ActionResult AddNews()
        {
            return View();
        }
        //POST Add News
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddNews(News model, HttpPostedFileBase imgfile)
        {
            string path = uploadingfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";

            }
            else
            {
                News news = new News();
                news.Date = model.Date;
                news.Description = model.Description;
                news.Title = model.Title;
                news.ImageUrl = path;
                db.News.Add(news);
                db.SaveChanges();
            }
            return RedirectToAction("NewsList");
        }
        // GET: Edit News
        public ActionResult EditNews(int id)
        {
            var model = db.News.Where(c => c.NewsId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Edit News
        [HttpPost]
        public ActionResult EditNews(int id, News model, HttpPostedFileBase imgfile)
        {
            var news = db.News.Where(c => c.NewsId == id).SingleOrDefault();
            string path = uploadingfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";

            }
            else
            {
                news.Date = model.Date;
                news.Description = model.Description;
                news.Title = model.Title;
                news.ImageUrl = path;
                db.SaveChanges();
            }
            return RedirectToAction("NewsList");
        }
        // GET: Delete News
        public ActionResult DeleteNews(int id)
        {
            var model = db.News.Where(c => c.NewsId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Delete News
        [HttpPost]
        public ActionResult DeleteNews(int id, News col)
        {
            var model = db.News.Where(c => c.NewsId == id).SingleOrDefault();
            db.News.Remove(model);
            db.SaveChanges();
            return RedirectToAction("NewsList");
        }
        #endregion

        #region Event Section

        // GET List Of Event
        public ActionResult EventsList()
        {
            var model = db.Events.ToList();
            return View(model);
        }
        //GET Add Event
        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }
        //POST Add Event
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddEvent(Event model, HttpPostedFileBase imgfile)
        {
            string path = uploadingfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";

            }
            else
            {
                Event evnt = new Event();
                evnt.Date = model.Date;
                evnt.Description = model.Description;
                evnt.Name = model.Name;
                evnt.ImageUrl = path;
                evnt.Venue = model.Venue;
                db.Events.Add(evnt);
                db.SaveChanges();
            }
            return RedirectToAction("EventsList");
        }
        // GET: Edit Event
        public ActionResult EditEvent(int id)
        {
            var model = db.Events.Where(c => c.EventId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Edit News
        [HttpPost]
        public ActionResult EditEvent(int id, Event model, HttpPostedFileBase imgfile)
        {
            var evnt = db.Events.Where(c => c.EventId == id).SingleOrDefault();
            string path = uploadingfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";

            }
            else
            {
                evnt.Date = model.Date;
                evnt.Description = model.Description;
                evnt.Name = model.Name;
                evnt.Venue = model.Venue;
                evnt.ImageUrl = path;
                db.SaveChanges();
            }
            return RedirectToAction("EventsList");
        }
        // GET: Delete News
        public ActionResult DeleteEvent(int id)
        {
            var model = db.Events.Where(c => c.EventId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Delete News
        [HttpPost]
        public ActionResult DeleteEvent(int id, Event col)
        {
            var model = db.Events.Where(c => c.EventId == id).SingleOrDefault();
            db.Events.Remove(model);
            db.SaveChanges();
            return RedirectToAction("EventsList");
        }
        #endregion

        #region Instructor Section

        // GET: Delete Teacher
        public ActionResult DeleteTeacher(string id, int idd)
        {
            var collection = new TeacherCollectionViewModel
            {
                Instructor = db.Instructors.Where(c => c.UserId == id).SingleOrDefault(),
                Instructor1 = db.Instructors.Where(c => c.InstructorId == idd).SingleOrDefault()
            };
            return View(collection);
        }

        // POST: Delete Student
        [HttpPost]
        public ActionResult DeleteTeacher(string id,int idd, TeacherCollectionViewModel col)
        {
            var instructor = db.Instructors.Where(c => c.UserId == id).SingleOrDefault();
            db.Instructors.Remove(instructor);
            var user = db.AspNetUsers.Where(c => c.Id == id).SingleOrDefault();
            db.AspNetUsers.Remove(user);
            var DepartmentRelation = db.DepartmentInstructorRelations.Where(c => c.InstructorId == idd).SingleOrDefault();
            db.DepartmentInstructorRelations.Remove(DepartmentRelation);
            db.SaveChanges();
            return RedirectToAction("TeachersList");
        }
        // GET: Edit Student
        public ActionResult EditTeacher(int id)
        {
            var collection = new TeacherCollectionViewModel
            {
                Instructor = db.Instructors.Where(c => c.InstructorId == id).SingleOrDefault(),
                Departments = db.Departments.ToList()
            };
            return View(collection);
        }

        // POST: Edit Student
        [HttpPost]
        public ActionResult EditTeacher(int id, TeacherCollectionViewModel model, HttpPostedFileBase imgfile)
        {
            var instructor = db.Instructors.Where(c => c.InstructorId == id).SingleOrDefault();
            string path = uploadingfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";

            }
            else
            {
                instructor.FirstName = model.Instructor.FirstName;
                instructor.LastName = model.Instructor.LastName;
                instructor.UserName = model.Instructor.UserName;
                instructor.UserRole = "Teacher";
                instructor.HireDate = model.Instructor.HireDate;
                instructor.Specialization = model.Instructor.Specialization;
                instructor.Descrimination = model.Instructor.Descrimination;
                instructor.Detail = model.Instructor.Detail;
                instructor.Password = model.Instructor.Password;
                instructor.Email = model.Instructor.Email;
                instructor.UserId = model.Instructor.UserId;
                instructor.ImageUrl = path;
                var user = db.AspNetUsers.Single(c => c.Id == model.Instructor.UserId);
                user.Email = model.Instructor.Email;
                user.UserName = model.Instructor.UserName;
                user.UserRole = "Teacher";
                user.Id = model.Instructor.UserId;
                db.SaveChanges();
            }
            return RedirectToAction("TeachersList");
        }

        // GET List Of Student
        public ActionResult TeachersList()
        {
            var model = db.Instructors.ToList();
            return View(model);
        }
        //GET Add Student
        [HttpGet]
        public ActionResult AddTeacher()
        {
            var collection = new TeacherCollectionViewModel
            {
                ApplicationUser = new RegisterViewModel(),
                Instructor = new Instructor(),
                Departments = db.Departments.ToList()
            };
            return View(collection);
        }
        //POST Add Student
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTeacher(TeacherCollectionViewModel model, HttpPostedFileBase imgfile)
        {
            var user = new ApplicationUser
            {
                UserName = model.ApplicationUser.UserName,
                Email = model.ApplicationUser.Email,
                UserRole = "Teacher",
            };
            var result = await UserManager.CreateAsync(user, model.ApplicationUser.Password).ConfigureAwait(false);
            if (result.Succeeded)
            {
                string path = uploadingfile(imgfile);
                if (path.Equals("-1"))
                {
                    ViewBag.error = "Image could not be uploaded";

                }
                else
                {
                    await UserManager.AddToRoleAsync(user.Id, "Teacher").ConfigureAwait(false);
                    var depart = db.Departments.Where(c => c.DepartmentId == model.DepartmentId).SingleOrDefault();
                    var instructor = new Instructor
                    {
                        FirstName = model.Instructor.FirstName,
                        LastName = model.Instructor.LastName,
                        Contact = model.Instructor.Contact,
                        Descrimination = model.Instructor.Descrimination,
                        Detail = model.Instructor.Detail,
                        Specialization = model.Instructor.Specialization,
                        HireDate = DateTime.Now,
                        ImageUrl = path,
                        Email = model.ApplicationUser.Email,
                        UserName = model.ApplicationUser.UserName,
                        Password = model.ApplicationUser.Password,
                        UserRole = "Teacher",
                        UserId = user.Id
                    };
                    var depRelation = new DepartmentInstructorRelation
                    {
                        InstructorId = instructor.InstructorId,
                        DepartmentId = depart.DepartmentId
                    };
                    db.DepartmentInstructorRelations.Add(depRelation);
                    db.Instructors.Add(instructor);
                    db.SaveChanges();
                    return RedirectToAction("TeachersList");
                }
                    
            }

            return HttpNotFound();

        }
        #endregion

        #region Course Section

        // GET List Of Course
        public ActionResult CoursesList()
        {
            var model = db.Courses.ToList();
            return View(model);
        }
        //GET Add Course
        [HttpGet]
        public ActionResult AddCourse()
        {
            var collection = new CourseCollectionViewModel
            {
                Course = new Course(),
                Departments = db.Departments.ToList(),
                Instructors = db.Instructors.ToList()
            };
            return View(collection);
        }
        //POST Add Course
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(CourseCollectionViewModel model, HttpPostedFileBase imgfile)
        {
            string path = uploadingfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";

            }
            else
            {
                var depart = db.Departments.Where(c => c.DepartmentId == model.DepartmentId).SingleOrDefault();
                var inst = db.Instructors.Where(c => c.InstructorId == model.InstructorId).SingleOrDefault();
                Course course = new Course();
                course.CreditHrs = model.Course.CreditHrs;
                course.Description = model.Course.Description;
                course.Title = model.Course.Title;
                course.ImageUrl = path;
                db.Courses.Add(course);
                var DepartmentRelation = new DepartmentCourseRelation
                {
                    CourseId = course.CourseId,
                    DepartmentId = depart.DepartmentId
                };
                db.DepartmentCourseRelations.Add(DepartmentRelation);
                var InstructorRelation = new InstructorCourseRelation
                {
                    CourseId = course.CourseId,
                    InstructorId = inst.InstructorId
                };
                db.InstructorCourseRelations.Add(InstructorRelation);
                db.SaveChanges();
            }
            return RedirectToAction("CoursesList");
        }
        // GET: Edit Course
        public ActionResult EditCourse(int id)
        {
            var model = db.Courses.Where(c => c.CourseId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Edit Course
        [HttpPost]
        public ActionResult EditCourse(int id, Course model, HttpPostedFileBase imgfile)
        {
            var course = db.Courses.Where(c => c.CourseId == id).SingleOrDefault();
            string path = uploadingfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";

            }
            else
            {
                course.CreditHrs = model.CreditHrs;
                course.Description = model.Description;
                course.Title = model.Title;
                course.ImageUrl = path;
                db.SaveChanges();
            }
            return RedirectToAction("CoursesList");
        }
        // GET: Delete Course
        public ActionResult DeleteCourse(int id)
        {
            var model = db.Courses.Where(c => c.CourseId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Delete Course
        [HttpPost]
        public ActionResult DeleteCourse(int id, Course col)
        {
            var course = db.Courses.Where(c => c.CourseId == id).SingleOrDefault();
            var DptRel = db.DepartmentCourseRelations.Where(c => c.CourseId == id).SingleOrDefault();
            db.DepartmentCourseRelations.Remove(DptRel);
            var InstRelation = db.InstructorCourseRelations.Where(c => c.CourseId == id).SingleOrDefault();
            db.InstructorCourseRelations.Remove(InstRelation);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("CoursesList");
        }
        #endregion

        #region Parent Student Relation Section
        //GET Make Relation ParentStudent
        [HttpGet]
        public ActionResult MakeParentStudentRelation()
        {
            var collection = new ParentStudentRelationViewModel
            {
                Parents = db.Parents.ToList(),
                Students = db.Students.ToList()
            };
            return View(collection);
        }

        //GET Make Relation ParentStudent
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult MakeParentStudentRelation(ParentStudentRelationViewModel model)
        {
            Student std = new Student { StudentId = model.StudentId};
            Parent prt = new Parent { ParentId = model.ParentId };
            db.SaveChanges();
            return View();
        }
        #endregion

        #region Complaints Manage Section
        // GET List Of Complaints
        public ActionResult ComplaintsList()
        {
            var model = db.complaints.ToList();
            return View(model);
        }
        // GET: Edit Complaint
        public ActionResult EditComplaint(int id)
        {
            var model = db.complaints.Where(c => c.complaintId == id).SingleOrDefault();
            return View(model);
        }

        // POST: Edit Complaint
        [HttpPost]
        public ActionResult EditComplaint(int id, complaint col)
        {
            var model = db.complaints.Where(c => c.complaintId == id).SingleOrDefault();
            model.Date = col.Date;
            model.Detail = col.Detail;
            model.IsViewed = col.IsViewed;
            db.SaveChanges();
            return RedirectToAction("ComplaintsList");
        }
        #endregion

        #region Challan Manage Section
        //GET Add Challan
        [HttpGet]
        public ActionResult AddChallan()
        {
            var collection = new ChallanCollectionViewModel
            {
                Chalan = new Chalan(),
                Students = db.Students.ToList(),
                StudentId = 0
            };
            return View(collection);
        }
        //GET Add Challan
        [HttpPost]
        public ActionResult AddChallan(ChallanCollectionViewModel model)
        {
            var challan = new Chalan()
            {
                ChalanDate = DateTime.Now,
                IsPaid = false,
                CurrentYear = DateTime.Now,
                Fee = model.Chalan.Fee
            };
            db.Chalans.Add(challan);
            var student = db.Students.Where(c => c.StudentId == model.Student.StudentId).SingleOrDefault();
            var Rel = new StudentChalanRelation()
            {
                StudentId = student.StudentId,
                ChalanId = challan.ChalanId
            };
            db.StudentChalanRelations.Add(Rel);
            db.SaveChanges();
            return RedirectToAction("ChallansList");
        }

        //GET All Challans List
        public ActionResult ChallansList()
        {
            var collection = db.Chalans.ToList();
            return View(collection);
        }

        //GET Edit Challan
        public ActionResult EditChallan(int id)
        {
            var collection = db.Chalans.Where(c => c.ChalanId == id).SingleOrDefault();
            return View(collection);
        }
        //Post Edit Challan
        [HttpPost]
        public ActionResult EditChallan(int id, Chalan model)
        {
            var challan = db.Chalans.Where(c => c.ChalanId == id).SingleOrDefault();
            challan.IsPaid = model.IsPaid;
            challan.Fee = model.Fee;
            db.SaveChanges();
            return RedirectToAction("ChallansList");
        }

        #endregion

    }
}
