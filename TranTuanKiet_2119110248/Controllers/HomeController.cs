using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Controllers
{
    public class HomeController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        public ActionResult Index()
        {
            HomeModel homeModel = new HomeModel();
            homeModel.lstCategory = webbanhang.Categories.ToList();
            homeModel.lstProduct = webbanhang.Products.ToList();
            return View(homeModel);
        }

    }
}