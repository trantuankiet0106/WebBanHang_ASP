using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248.Models
{
    public class MasterOder
    {
        public int id { get; set; }
        public List<Order> ListOrder { get; set; }
        public new List<OrderDetail> ListOrderDetail { get; set; }
        public new List<User> ListUser { get; set; }
        public new List<Product> ListPro { get; set; }
        
    }
}