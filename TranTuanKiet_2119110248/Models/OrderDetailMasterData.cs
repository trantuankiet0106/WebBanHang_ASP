using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Context
{
    public partial class OrderDetailMasterData
    {
      
        [Display(Name = "Mã chi Tiết")]
        public int id { get; set; }

        [Display(Name = "Mã Đơn hàng")]
        public Nullable<int> OrderId { get; set; }

        [Display(Name = "Mã Sản Phẩm")]
        public Nullable<int> ProductId { get; set; }

        [Display(Name = "Số lượng")]
        public Nullable<int> Quantity { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        public string ProductName { get; set; }

        [Display(Name = "Tổng Giá trị")]
        public Nullable<double> price { get; set; }

        [Display(Name = "Giá Sản Phẩm")]
        public Nullable<double> prices { get; set; }

        public string AvataOrder { get; set; }
    }
}