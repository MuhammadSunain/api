//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ecomapi1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Role1 { get; set; }
        public Nullable<int> client { get; set; }
        public Nullable<int> entityId { get; set; }
    }
}
