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
    
    public partial class Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees()
        {
            this.PinCodes = new HashSet<PinCodes>();
            this.Timesheets = new HashSet<Timesheets>();
        }
    
        public int Id_Employee { get; set; }
        public Nullable<int> Id_Contractor { get; set; }
        public Nullable<int> Id_Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string EmployeeReference { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public bool Active { get; set; }
        public byte[] EmployeePicture { get; set; }
    
        public virtual Contractors Contractors { get; set; }
        public virtual Departments Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PinCodes> PinCodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timesheets> Timesheets { get; set; }
    }
}
