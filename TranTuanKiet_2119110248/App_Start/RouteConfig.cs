using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TranTuanKiet_2119110248
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //promotion
            routes.MapRoute(
                name: "Promotion",
                url: "San-pham-dang-giam-gia",
                defaults: new { controller = "Category", action = "Promotion", id = UrlParameter.Optional },
                                new[] { "TranTuanKiet_2119110248.Controllers" }

            );
            //Detail
            routes.MapRoute(
              name: "Detail",
              url: "chi-tiet-san-pham/{name}",
              defaults: new { controller = "Product", action = "Detail", nam = UrlParameter.Optional },
                              new[] { "TranTuanKiet_2119110248.Controllers" }

          );
            //Categorygrid
            routes.MapRoute(
              name: "ProductCategorygrid",
              url: "Danh-sach-San-Pham/{id}",
              defaults: new { controller = "Product", action = "ProductCategorygrid", id = UrlParameter.Optional },
                              new[] { "TranTuanKiet_2119110248.Controllers" }

          );
            //shopingcart
            routes.MapRoute(
             name: "Shoppingcart",
             url: "Gio-hang",
             defaults: new { controller = "Shoppingcart", action = "Shoppingcart", id = UrlParameter.Optional },
                             new[] { "TranTuanKiet_2119110248.Controllers" }

         );
            //Index
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                               new[] { "TranTuanKiet_2119110248.Controllers" }

           );
        }
    }
}
