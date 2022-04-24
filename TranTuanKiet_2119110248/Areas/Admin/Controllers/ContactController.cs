using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Admin/Contact
        public ActionResult Index()
        {
            var contact = webbanhang.Contacts.ToList();
            return View(contact);
        }
    }
}