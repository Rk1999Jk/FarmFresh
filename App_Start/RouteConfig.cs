using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using WebApplication4.Models;

namespace WebApplication4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                   name: "MyCustomRoute",
                    url:"Home/UserCategorySelection/{select}",
                    defaults:new { controller = "Home", action = "UserCategorySelection", select = UrlParameter.Optional }
            );
            routes.MapRoute(
                   name: "MyCustom",
                    url:"Home/AvailableProducts/{select}",
                    defaults:new { controller = "Home", action = "UserCategorySelection", select = UrlParameter.Optional }
            );
            routes.MapRoute(
                   name: "MyRoute",
                    url: "Views/Home/UserCartIndexAfter.cshtml",
                    defaults: new { controller = "Home", action = "UserCartIndexAfter", select = UrlParameter.Optional }
            );



        }
    }
}
