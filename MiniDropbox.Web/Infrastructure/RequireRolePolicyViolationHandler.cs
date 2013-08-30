using System.Web.Mvc;
using System.Web.Routing;
using FluentSecurity;

namespace MiniDropbox.Web.Infrastructure
{
    public class RequireRolePolicyViolationHandler : IPolicyViolationHandler
    {
        public ActionResult Handle(PolicyViolationException exception)
        {
            return new RedirectToRouteResult("LogIn",
                                             new RouteValueDictionary { { "error", "You don't have access here" } });
        }
    }
}