using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;


using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;
using static TranTuanKiet_2119110248.Common;

namespace TranTuanKiet_2119110248.Areas.Admin.Controllers
{
    public class OrderManagementController : Controller
    {
       
             //private DetailOrder  =
             Webbanhang webbanhang = new Webbanhang();
        // GET: Admin/OrderManagement
      [HttpGet]
        
        public ActionResult Index()
        {

            var lstOr = webbanhang.Orders.ToList();
            return View(lstOr);
        }
      
        public ActionResult Detail(int id)
        {

            MasterOder chitiet  = new MasterOder();
          

            var lstDetail = webbanhang.OrderDetails.Where(n => n.OrderId == id).ToList();
            var lstOrder = webbanhang.Orders.Where(n => n.Id == id).ToList();
            var lstPro = webbanhang.Products.Where(n => n.ProductId == id).ToList();
            chitiet.id = id;
            chitiet.ListOrderDetail = lstDetail;
            chitiet.ListOrder =lstOrder;
            chitiet.ListPro =lstPro;
            return View(chitiet);
        }

    }
}