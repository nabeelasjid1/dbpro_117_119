using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class ParentAdminStudentRelationViewModel
    {
        public List<Course> Courses { get; set; }
        public Student Student { get; set; }
        public List<Event> Events { get; set; }
        public List<Hostel> Hostels { get; set; }
        public List<Student> Students { get; set; }
        public int HostelId { get; set; }
        public Hostel Hostel { get; set; }
        public List<complaint> Complaints { get; set; }
        public complaint Complaint { get; set; }
    }
}