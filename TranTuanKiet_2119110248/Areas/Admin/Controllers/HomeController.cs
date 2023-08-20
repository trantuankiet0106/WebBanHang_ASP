using System.Linq;
using System.Web.Mvc;
using TranTuanKiet_2119110248.Context;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        Webbanhang webbanhang = new Webbanhang();
        // GET: Admin/Home
        public ActionResult Index()
        {
            MasterOder masterOder = new MasterOder();
            masterOder.ListOrderDetail = webbanhang.OrderDetails.ToList();
            masterOder.ListUser = webbanhang.Users.ToList();
            masterOder.ListOrder = webbanhang.Orders.ToList();
            ViewBag.User = webbanhang.Users.Where(n=>n.UserName!=null).ToList();
            return View(masterOder);
           


        }
    }
}