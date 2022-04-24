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
    public class CategoryController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            var lstCat = webbanhang.Categories.ToList();
            return View(lstCat);

        }
        [HttpGet]
        // thêm mới
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Category objCat)
        {
           


            try
            {
                if (objCat.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objCat.ImageUpload.FileName);
                    string extension = Path.GetExtension(objCat.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objCat.avatar = fileName;
                    objCat.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/Category"), fileName));
                }
                webbanhang.Categories.Add(objCat);
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
            var Category = webbanhang.Categories.Where(n => n.id == id).FirstOrDefault();
            return View(Category);
        }


        //Delete
        [HttpGet]

        public ActionResult Delete(int id)
        {
            var objCat = webbanhang.Categories.Where(n => n.id == id).FirstOrDefault();
            return View(objCat);
        }
        [HttpPost]
        public ActionResult Delete(Category objC)
        {
            var objCat = webbanhang.Categories.Where(n => n.id == objC.id).FirstOrDefault();
            webbanhang.Categories.Remove(objCat);
            webbanhang.SaveChanges();
            return RedirectToAction("Index");
        }

        //edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objCat = webbanhang.Categories.Where(n => n.id == id).FirstOrDefault();

            return View(objCat);
        }
        [HttpPost]
        public ActionResult Edit(Category objC)
        {
            if (objC.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objC.ImageUpload.FileName);
                string extension = Path.GetExtension(objC.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objC.avatar = fileName;
                objC.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/Category"),fileName));
            }
            webbanhang.Entry(objC).State = EntityState.Modified;
            webbanhang.SaveChanges();
            return View(objC);
        }
    }
}