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
    
    public partial class StudentChalanRelation
    {
        public int StudentId { get; set; }
        public int ChalanId { get; set; }
        public int Id { get; set; }
    
        public virtual Chalan Chalan { get; set; }
        public virtual Student Student { get; set; }
    }
}