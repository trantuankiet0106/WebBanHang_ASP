using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Controllers
{
    public class PaymentController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();

        // GET: Payment
        public ActionResult Index()
            
        {
            CartModel cartmodel = new CartModel();

            var product = webbanhang.Products.ToList();

            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];

                Order objorder = new Order();
              
                    objorder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHmmss");
                    objorder.UserId = int.Parse(Session["idUser"].ToString());
                    objorder.CreatedOnUtc = DateTime.Now;
                    objorder.Status = 1;
                 
                  

                    webbanhang.Orders.Add(objorder);
                    webbanhang.SaveChanges();
                
               
                int intOrderId = objorder.Id;
                List<OrderDetail> lstOrderDetail = new List<OrderDetail>(); 
                foreach(var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.ProductId;
                    //thêm tên sản phẩm
                    obj.ProductName = item.Product.ProductName;
                    obj.price = item.Product.ProductPrice * obj.Quantity;
                    obj.prices= item.Product.ProductPrice ;
                    lstOrderDetail.Add(obj);
                }
                webbanhang.OrderDetails.AddRange(lstOrderDetail);
                webbanhang.SaveChanges();
            }
            return View();
        }
    }
}