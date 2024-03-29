//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileBackendApiMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkAssignments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkAssignments()
        {
            this.Timesheets = new HashSet<Timesheets>();
        }
    
        public int Id_WorkAssignment { get; set; }
        public Nullable<int> Id_Customer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public bool InProgress { get; set; }
        public Nullable<System.DateTime> InProgressAt { get; set; }
        public bool Completed { get; set; }
        public Nullable<System.DateTime> CompletedAt { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> LastModifiedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public bool Active { get; set; }
    
        public virtual Customers Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timesheets> Timesheets { get; set; }
    }
}
