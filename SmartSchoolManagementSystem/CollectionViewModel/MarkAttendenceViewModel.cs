using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class MarkAttendenceViewModel
    {
        public List<Student> Students { get; set; }
        public Student Student { get; set; }
        public List<Lookup> Lookups { get; set; }
        public Lookup Lookup { get; set; }
    }
}