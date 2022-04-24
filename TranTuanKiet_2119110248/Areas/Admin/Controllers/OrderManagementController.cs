using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Areas.Admin.Controllers
{
    public class OrderManagementController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Admin/OrderManagement
      [HttpGet]
        public ActionResult HOME()
        {
            MasterOder master = new MasterOder();
            master.ListOrder = webbanhang.Orders.ToList();
            master.ListOrderDetail = webbanhang.OrderDetails.ToList();

            return View(master);
        }
    }
}