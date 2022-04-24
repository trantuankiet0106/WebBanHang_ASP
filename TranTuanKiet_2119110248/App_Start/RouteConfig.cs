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
              url: "chi-tiet-san-pham/{id}",
              defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                              new[] { "TranTuanKiet_2119110248.Controllers" }

          );
            //Categorygrid
            routes.MapRoute(
              name: "ProductCategorygrid",
              url: "Danh-sach-San-Pham/{id}",
              defaults: new { controller = "Product", action = "ProductCategorygrid", id = UrlParameter.Optional },
                              new[] { "TranTuanKiet_2119110248.Controllers" }

          );
            //CategoryList
            routes.MapRoute(
              name: "BrandList",
              url: "List-Danh-sach-San-Pham/{id}",
              defaults: new { controller = "Product", action = "ProductCategoryList", id = UrlParameter.Optional },
                              new[] { "TranTuanKiet_2119110248.Controllers" }

          );
            //Brandlisst
            routes.MapRoute(
              name: "ProductBrandList",
              url: "Danh-sach-San-Pham-theo-thuong-hieu/{id}",
              defaults: new { controller = "Product", action = "ProductBrandList", id = UrlParameter.Optional },
                              new[] { "TranTuanKiet_2119110248.Controllers" }

          );

            //shopingcart
            routes.MapRoute(
             name: "Shoppingcart",
             url: "Gio-hang",
             defaults: new { controller = "Shoppingcart", action = "Shoppingcart", id = UrlParameter.Optional },
                             new[] { "TranTuanKiet_2119110248.Controllers" }
         );
            //Contact
            routes.MapRoute(
            name: "Contact",
            url: "Lien-he-voi-chung-toi",
            defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                            new[] { "TranTuanKiet_2119110248.Controllers" }
        );
            //Login
            routes.MapRoute(
            name: "Login",
            url: "dang-nhap",
            defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional },
                            new[] { "TranTuanKiet_2119110248.Controllers" }
        );
            //register
            routes.MapRoute(
            name: "Register",
            url: "dang-ky",
            defaults: new { controller = "Home",action ="Register", id = UrlParameter.Optional },
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
