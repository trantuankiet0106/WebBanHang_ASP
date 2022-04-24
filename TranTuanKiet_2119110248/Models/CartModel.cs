using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248.Models
{
    public class CartModel
    {
        public Product Product { get; set; }
        public new List<Product> lstProduct { get; set; }
        public new List<OrderDetail> orderDetails { get; set; }
        public int Quantity { get; set; }
        
    }
}