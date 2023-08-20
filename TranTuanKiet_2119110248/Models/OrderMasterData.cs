using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Context
{
    public class OrderMasterData
    {
        [Display(Name = "Mã Đơn hàng")]
        public int Id { get; set; }

        [Display(Name = "Tên Đơn hàng")]
        public string Name { get; set; }

        public Nullable<int> UserId { get; set; }

        [Display(Name = "Thời gian đặt hàng")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<int> Status { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        public string ProducName { get; set; }
        public Nullable<double> price { get; set; }

        [Display(Name = "Tên Khách Hàng")]
        public string UserName { get; set; }
        public string Diachi { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}