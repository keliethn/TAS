//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TAS
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> Role { get; set; }
        public bool Status { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Role Role1 { get; set; }
    }
}
