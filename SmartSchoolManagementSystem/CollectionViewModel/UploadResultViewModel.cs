using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class UploadResultViewModel
    {
        public List<Student> Students { get; set; }
        public Student Student { get; set; }
        public StudentResult StudentResult { get; set; }
        public List<StudentResult> StudentResults { get; set; }
        public List<Course> Courses { get; set; }
        public Course Course { get; set; }
        public string Grade { get; set; }
        public List<Lookup> Lookups { get; set; }
        public Lookup Lookup { get; set; }
    }
}