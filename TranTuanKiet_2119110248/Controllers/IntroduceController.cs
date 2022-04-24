using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Controllers
{
    public class IntroduceController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Introduce
        public ActionResult Introduce()
        {
            HomeModel about = new HomeModel();
            about.lstabouts = webbanhang.Abouts.ToList();
            return View(about);
        }
    }
}