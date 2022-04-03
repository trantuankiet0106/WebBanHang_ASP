using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Admin/Product
        public ActionResult Index(string currentFilter,string searchString,int? page)
        {
            var lstProduct = new List<Product>();
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if(!string.IsNullOrEmpty(searchString))
            {
                lstProduct = webbanhang.Products.Where(n => n.ProductName.Contains(searchString)).ToList();
            }
            else
            {
                lstProduct = webbanhang.Products.ToList();
            }
            ViewBag.currentFilter = searchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.ProductId).ToList();
        return View(lstProduct.ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            try
            {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                webbanhang.Products.Add(objProduct);
                webbanhang.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = webbanhang.Products.Where(n => n.ProductId == id).FirstOrDefault();
            return View(objProduct);
        }
        //Delete
        [HttpGet]

        public ActionResult Delete(int id)
        {
            var objProduct = webbanhang.Products.Where(n => n.ProductId == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = webbanhang.Products.Where(n => n.ProductId == objPro.ProductId).FirstOrDefault();
            webbanhang.Products.Remove(objProduct);
            webbanhang.SaveChanges();
            return RedirectToAction("Index");
        }
        //edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = webbanhang.Products.Where(n => n.ProductId == id).FirstOrDefault();

            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product objProduct)
        {
            if (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            webbanhang.Entry(objProduct).State = EntityState.Modified;
            webbanhang.SaveChanges();
            return View(objProduct);
        }
    }
}