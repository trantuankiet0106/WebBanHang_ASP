using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248
{
    public class OrderDetailMaster
    {
        Webbanhang  webbanhang = new Webbanhang();
        public List<OrderDetail>getlistDetail(int? orderid )
        {
            return webbanhang.OrderDetails.Where(m=>m.OrderId==orderid).ToList();
        }
        public List<OrderDetail> getlistDetail(string page = "ALL")
        {
            List<OrderDetail> list = webbanhang.OrderDetails.ToList();
            return list;
        }
    }
}