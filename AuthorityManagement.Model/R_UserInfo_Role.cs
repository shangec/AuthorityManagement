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
    
    public partial class R_UserInfo_Role
    {
        public int ID { get; set; }
        public Nullable<int> UserInfoID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public int UserInfoID1 { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
        public virtual Role Role { get; set; }
    }
}
