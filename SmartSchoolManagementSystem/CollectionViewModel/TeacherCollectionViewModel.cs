using SmartSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class TeacherCollectionViewModel
    {
        public RegisterViewModel ApplicationUser { get; set; }
        public Instructor Instructor { get; set; }
        public Instructor Instructor1 { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}