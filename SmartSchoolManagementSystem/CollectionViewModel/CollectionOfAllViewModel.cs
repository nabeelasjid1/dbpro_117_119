using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class CollectionOfAllViewModel
    {
        public List<Department> Departments { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Parent> Parents { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Hostel> Hostels { get; set; }
        public IEnumerable<Notice> Notices { get; set; }
        public IEnumerable<complaint> Complaints { get; set; }
        public Department Department { get; set; }
        public Student Student { get; set; }
        public Parent Parent { get; set; }
        public Instructor Instructor { get; set; }
        public News New { get; set; }
        public Event Event { get; set; }
        public Course Course { get; set; }
        public Hostel Hostel { get; set; }
        public Notice Notice { get; set; }

    }
}