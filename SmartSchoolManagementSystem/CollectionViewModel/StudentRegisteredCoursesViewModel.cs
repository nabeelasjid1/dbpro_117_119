using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class StudentRegisteredCoursesViewModel
    {
        public Course Course { get; set; }
        public StudentRegisteredCoursesViewModel Relation { get; set; }

    }
}