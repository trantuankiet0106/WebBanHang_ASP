using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Controllers
{
    public class HomeController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();

        public ActionResult Index()

        {


            HomeModel homeModel = new HomeModel();
            homeModel.lstCategory = webbanhang.Categories.ToList();
            homeModel.lstProduct = webbanhang.Products.ToList();
            homeModel.lstSlides = webbanhang.Slides.ToList();
            return View(homeModel);
        }
        [HttpGet]
        public ActionResult Login()
        {
        
            return View();
        }

        public ActionResult Register()
        {
        
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = webbanhang.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    webbanhang.Configuration.ValidateOnSaveEnabled = false;
                    webbanhang.Users.Add(_user);
                    webbanhang.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = webbanhang.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FistName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().UserID;
                    Session["Admin"] = data.FirstOrDefault().Admin;
                  if(Session["Admin"]!=null)
                    {
                        return RedirectToAction("Index", "Admin/Home");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {

         
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

    }

}
