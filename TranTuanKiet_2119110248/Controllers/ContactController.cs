using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248.Controllers
{
    public class ContactController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Contact
        public ActionResult Index()
        {
            var contact = webbanhang.Contacts.Single(x=>x.Status==1);
            return View(contact);
        }
    }
}