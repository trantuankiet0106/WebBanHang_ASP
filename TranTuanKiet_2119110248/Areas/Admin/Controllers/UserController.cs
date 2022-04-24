using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.MobileControls;
using System.Windows.Documents;
using TranTuanKiet_2119110248.Context;
using static TranTuanKiet_2119110248.Common;

namespace TranTuanKiet_2119110248.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        Webbanhang webbanhang = new Webbanhang();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstUser = webbanhang.Users.ToList();
            return View(lstUser);

        }

      
        
        //chi tiết
        [HttpGet]
        public ActionResult Details(int id)
        {
            var Brand = webbanhang.Users.Where(n => n.UserID == id).FirstOrDefault();
            return View(Brand);
        }


        //Delete
      
        //edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = webbanhang.Users.Where(n => n.UserID == id).FirstOrDefault();

            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(User objB)
        {
            
            webbanhang.Entry(objB).State = EntityState.Modified;
            webbanhang.SaveChanges();
            return View(objB);
        }

    }
}