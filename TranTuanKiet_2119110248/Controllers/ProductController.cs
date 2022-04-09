using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Controllers
{
    public class ProductController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Product
        public ActionResult Detail(int id)
        {
            HomeModel homeModel = new HomeModel();
           
            homeModel.lstProduct = webbanhang.Products.ToList();
            var product = webbanhang.Products.Where(n => n.ProductId == id).FirstOrDefault();
           
            return View(product);
        }
        public ActionResult ProductCategoryList(int id )
        {

            ProductCategory productCat = new ProductCategory();
            var lstproductCat = webbanhang.Products.Where(n => n.CategoryId == id).ToList();
            var lstCategory = webbanhang.Categories.Where(n => n.id == id).ToList();

            productCat.id = id;
            productCat.listCategory = lstCategory;
            productCat.listProducts = lstproductCat;
            return View(productCat);
        }
        public ActionResult ProductCategorygrid(int id)
        {
            ProductCategory productCat = new ProductCategory();
            var lstproductCat = webbanhang.Products.Where(n => n.CategoryId == id).ToList();
            var lstCategory = webbanhang.Categories.Where(n => n.id == id).ToList();

            productCat.id = id;
            productCat.listCategory = lstCategory;
            productCat.listProducts = lstproductCat;
            return View(productCat);
        }
       

    }
}