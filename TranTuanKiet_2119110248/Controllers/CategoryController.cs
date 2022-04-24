using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;
using PagedList;




namespace TranTuanKiet_2119110248.Controllers
{
    public class CategoryController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Category
        public ActionResult Category()
        {
           
            var Category = webbanhang.Categories.ToList(); 
            return View(Category);
        }   
        public ActionResult Promotion(string currentFilter, string searchString, int? page)
        {
          
            var lstProduct = new List<Product>();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                lstProduct = webbanhang.Products.Where(n => n.ProductName.Contains(searchString)).ToList();
            }
            else
            {
                lstProduct = webbanhang.Products.ToList();
            }
            ViewBag.currentFilter = searchString;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.PriceDiscount !=null).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));



        }
    }
}