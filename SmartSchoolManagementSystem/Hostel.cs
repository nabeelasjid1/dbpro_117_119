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
    
    public partial class Hostel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hostel()
        {
            this.StudentHostelRelations = new HashSet<StudentHostelRelation>();
        }
    
        public int HostelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Capacity { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentHostelRelation> StudentHostelRelations { get; set; }
    }
}
