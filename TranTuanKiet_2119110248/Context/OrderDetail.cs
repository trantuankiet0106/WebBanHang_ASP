﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;

    public partial class OrderDetail
    {
        public int id { get; set; }
        [Display(Name = "Mã đơn hàng")]
        public Nullable<int> OrderId { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public Nullable<int> ProductId { get; set; }
        [Display(Name = "Số lượng")]
        public Nullable<int> Quantity { get; set; }
        [Display(Name = "Tên sản Phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Tổng Giá Trị Sản Phẩm")]
        public Nullable<double> price { get; set; }
        [Display(Name = "Giá sản Phẩm")]
        public Nullable<double> prices { get; set; }
    }
}
