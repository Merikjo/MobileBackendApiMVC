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
    
    public partial class PinCodes
    {
        public int Id_PinCode { get; set; }
        public string PinCode { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> LastModifiedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public bool Active { get; set; }
        public Nullable<int> Id_Employee { get; set; }
        public Nullable<int> Id_Customer { get; set; }
        public Nullable<int> Id_Contractor { get; set; }
    
        public virtual Contractors Contractors { get; set; }
        public virtual Customers Customers { get; set; }
        public virtual Employees Employees { get; set; }
    }
}