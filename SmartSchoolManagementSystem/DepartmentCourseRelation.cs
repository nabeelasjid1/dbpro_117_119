//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartSchoolManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartmentCourseRelation
    {
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
        public int Id { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Department Department { get; set; }
    }
}
