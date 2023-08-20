using Facebook;
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
using System.Configuration;
using Microsoft.Azure.Management.ContainerService.Fluent.Models;
using static TranTuanKiet_2119110248.Common;
using static System.Resources.ResXFileRef;
using System.Data;
using System.Windows;
using System.Web.UI;

namespace TranTuanKiet_2119110248.Controllers
{
    public class HomeController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });


            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var user = new User();
                user.Email = email;
                user.UserName = email;

                user.UserName = firstname + " " + middlename + " " + lastname;
                user.CreaterDate = DateTime.Now;

            }
            return Redirect("/");
        }
        public ActionResult LoginFB()
        {
            var fb = new FacebookClient();
            var LoginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_Secret = ConfigurationManager.AppSettings["FbAppSecret"],

                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "Email",
            });
            return Redirect(LoginUrl.AbsoluteUri);
        }
        public ActionResult Index()

        {
            HomeModel homeModel = new HomeModel();
            homeModel.lstCategory = webbanhang.Categories.ToList();
            homeModel.lstProduct = webbanhang.Products.ToList();
            homeModel.lstSlides = webbanhang.Slides.ToList();
            homeModel.lstBrand = webbanhang.Brands.ToList();


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
                    ViewBag.error = "Email Tồn tại";

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
                    Session["Address"] = data.FirstOrDefault().Address;
                    Session["Phone"] = data.FirstOrDefault().Phone;


                    if (Session["Admin"] != null)
                    {
                        return RedirectToAction("Index", "Admin/Home");
                    }
                    else
                    {

                       return RedirectToAction("Index");
                       // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");

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
                            return RedirectToAction("Login","Home");
          
        }
        //login khi gio hang co san pham
        [HttpGet]
        public ActionResult Login2()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login2(string email, string password)
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
                    Session["Address"] = data.FirstOrDefault().Address;
                    Session["Phone"] = data.FirstOrDefault().Phone;



                        return RedirectToAction("Shoppingcart", "Shoppingcart");

                    
                }
                else
                {

                    ViewBag.error = "Đăng nhập thất bại";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

    }

}
