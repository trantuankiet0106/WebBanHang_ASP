using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Context
{
    public partial class Oder
    {
        [Display(Name = "Mã đơn hàng")]
        public int Id { get; set; }
        [Display(Name = "Tên đơn hàng")]
        public string Name { get; set; }
        [Display(Name = "Mã Khách hàng")]
        public Nullable<int> UserId { get; set; }

        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Trạng Thái đơn hàng")]
        public Nullable<int> Status { get; set; }

        public string ProducName { get; set; }
        public Nullable<double> price { get; set; }
    }
}