using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.MobileControls;
using System.Windows.Documents;
using TranTuanKiet_2119110248.Context;
using static TranTuanKiet_2119110248.Common;

namespace TranTuanKiet_2119110248.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();

      
        // GET: Admin/Product
        public ActionResult Index(string currentFilter,string searchString,int? page)
        {
            var lstProduct = new List<Product>();
            var lstcat = new List<Category>();
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
            lstProduct = lstProduct.OrderByDescending(n => n.ProductId).Where(n=>n.IsDelete==false).ToList();
    
        return View(lstProduct.ToPagedList(pageNumber,pageSize));
        }
        //------------------
        public ActionResult Viewrecycle(string currentFilter, string searchString, int? page)
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
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.ProductId).Where(n=>n.IsDelete==true).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
        //---------
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
           
            return View();
        }

        private void LoadData()
        {
            Common common = new Common();
            var lstCat = webbanhang.Categories.ToList();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = common.ToSelectList(dtCategory, "id", "name");


            var lstBrand = webbanhang.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            ViewBag.ListBrand = common.ToSelectList(dtBrand, "BranID", "BrandName");

            List<ProductType> lstproductType = new List<ProductType>();
            ProductType productType1 = new ProductType();
            productType1.Id = 01;
            productType1.Name = "Giảm giá sốc";
            lstproductType.Add(productType1);

            productType1 = new ProductType();
            productType1.Id = 02;
            productType1.Name = "Đề xuất";
            lstproductType.Add(productType1);
            DataTable dtProType = converter.ToDataTable(lstproductType);
            ViewBag.ListProType = common.ToSelectList(dtProType, "Id", "Name");

         
        }

        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();
           
                try
                {
                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/Product"), fileName));
                   
                    }
                    objProduct.IsDelete = false;
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
            this.LoadData();
            var objProduct = webbanhang.Products.Where(n => n.ProductId == id).FirstOrDefault();
       
            return View(objProduct);
        }
      
        [HttpPost]
        public ActionResult Edit(Product objPro)
        {
            this.LoadData();
            if (objPro.ImageUpload != null)
                {

                    string fileName = Path.GetFileNameWithoutExtension(objPro.ImageUpload.FileName);
                    string extension = Path.GetExtension(objPro.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objPro.Avatar = fileName;
                objPro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/Product"), fileName));
                }
                webbanhang.Entry(objPro).State = EntityState.Modified;
                webbanhang.SaveChanges();

            return RedirectToAction("Index");



        }

        //thung rac

        [HttpGet]
        public ActionResult Recycle(int id)
        {
            var objProduct = webbanhang.Products.Where(n => n.ProductId == id).FirstOrDefault();
            return View(objProduct);
        }

        //-------------
        public ActionResult restore(int Id)
        {
            Product prod = webbanhang.Products.Find(Id);
            prod.IsDelete = false;

            webbanhang.SaveChanges();
            return RedirectToAction("Viewrecycle", "Product");
        }

       
        public ActionResult Del(int Id)
        {
            
            Product prod = webbanhang.Products.Find(Id);
            prod.IsDelete = true;
            webbanhang.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

    }
}