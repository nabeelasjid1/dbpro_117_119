using SmartSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class StudentCollectionViewModel
    {
        public RegisterViewModel ApplicationUser { get; set; }
        public Student Student { get; set; }
        public Student Student1 { get; set; }
        public int ParentId { get; set; }
        public int DepartmentId { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Student> Students { get; set; }
        public List<Department> Departments { get; set; }
    }
}