using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248.Areas.Admin.Models
{
    public class MasterOder
    {
        public List<Order> listOrder { get; set; }
        public List<OrderDetail> ListOrderDetail { get; set; }
    }
}