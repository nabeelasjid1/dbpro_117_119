using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class CourseCollectionViewModel
    {
        public Course Course { get; set; }
        public List<Course> Courses { get; set; }
        public List<Department> Departments { get; set; }
        public int DepartmentId { get; set; }
        public List<Instructor> Instructors { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public InstructorCourseRelation Relation { get; set; }

    }
}