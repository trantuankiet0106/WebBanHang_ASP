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
    public class BrandController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            var lstBrand = webbanhang.Brands.ToList();
            return View(lstBrand);
         
        }
        [HttpGet]
        // thêm mới
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand objBrand)
        {
            try
            {
                if (objBrand.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                    string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objBrand.Avatar = fileName;
                    objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/Brand"), fileName));
                }
                webbanhang.Brands.Add(objBrand);
                webbanhang.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }

        }
        //chi tiết
        [HttpGet]
        public ActionResult Details(int id)
        {
            var Brand = webbanhang.Brands.Where(n => n.BranID == id).FirstOrDefault();
            return View(Brand);
        }
    
    
        //Delete
        [HttpGet]

        public ActionResult Delete(int id)
        {
            var objBrand = webbanhang.Brands.Where(n => n.BranID == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Delete(Brand objB)
        {
            var objBrand = webbanhang.Brands.Where(n => n.BranID == objB.BranID).FirstOrDefault();
            webbanhang.Brands.Remove(objBrand);
            webbanhang.SaveChanges();
            return RedirectToAction("Index");
        }

        //edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = webbanhang.Brands.Where(n => n.BranID == id).FirstOrDefault();

            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(Brand objB)
        {
            if (objB.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objB.ImageUpload.FileName);
                string extension = Path.GetExtension(objB.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objB.Avatar = fileName;
                objB.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/Brand"), fileName));
            }
            webbanhang.Entry(objB).State = EntityState.Modified;
            webbanhang.SaveChanges();
            return View(objB);
        }
    }
}