using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Admin/Home
        public ActionResult Index()
        {
            //if (Session["idUser"] != null)
            //{
            //    var lstProduct = webbanhang.Products.ToList();
            //    return View(lstProduct);
            //}
            //else
            //{
            return View("Index");
            //}


        }
    }
}