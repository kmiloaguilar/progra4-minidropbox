using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using MiniDropbox.Web.Controllers;
using NavigationRoutes;

namespace BootstrapMvcSample
{
    public class ExampleLayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapNavigationRoute<DiskController>("My Disk", c => c.Index());

            routes.MapNavigationRoute<AccountController>("Profile", c => c.Index())
                  .AddChildRoute<AccountController>("Sign Out", c => c.LogOut())
                ;
        }
    }
}
