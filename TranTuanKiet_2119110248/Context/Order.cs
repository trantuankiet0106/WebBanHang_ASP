//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TranTuanKiet_2119110248.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<int> Status { get; set; }
        public string ProducName { get; set; }
        public Nullable<double> price { get; set; }
        public string UserName { get; set; }
        public string Diachi { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
