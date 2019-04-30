using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class ChallanCollectionViewModel
    {
        public List<Student> Students { get; set; }
        public List<Chalan> Chalans { get; set; }
        public Chalan Chalan { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}