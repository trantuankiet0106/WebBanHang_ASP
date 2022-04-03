using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Controllers
{
    public class PaymentController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();

        // GET: Payment
        public ActionResult Index()
        {
            if(Session["idUser"]==null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                Order objorder = new Order();
                
            }
            return View();
        }
    }
}