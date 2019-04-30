using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class ParentStudentRelationViewModel
    {
        public int ParentId { get; set; }
        public int StudentId { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Student> Students { get; set; }
    }
}