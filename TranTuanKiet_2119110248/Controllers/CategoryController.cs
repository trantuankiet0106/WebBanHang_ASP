using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Controllers
{
    public class CategoryController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Category
        public ActionResult Category()
        {
            //var product = webbanhang.Products.Where(n => n.ProductId == id).FirstOrDefault();
            var Category = webbanhang.Categories.ToList(); 
            return View(Category);
        }
    }
}