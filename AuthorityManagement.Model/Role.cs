//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthorityManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.R_UserInfo_Role = new HashSet<R_UserInfo_Role>();
            this.ActionGroup = new HashSet<ActionGroup>();
        }
    
        public int ID { get; set; }
        public string RoleName { get; set; }
        public Nullable<int> RoleType { get; set; }
        public bool DelFlag { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
    
        public virtual ICollection<R_UserInfo_Role> R_UserInfo_Role { get; set; }
        public virtual ICollection<ActionGroup> ActionGroup { get; set; }
    }
}