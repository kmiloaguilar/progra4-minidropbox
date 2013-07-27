using System.Web.Mvc;
using BootstrapMvcSample.Controllers;
using MiniDropbox.Web.Models;

namespace MiniDropbox.Web.Controllers
{
    public class AccountController : BootstrapBaseController
    {
        [HttpGet]
        public ActionResult LogIn()
        {
            return View(new AccountLoginModel());
        }

        [HttpPost]
        public ActionResult LogIn(AccountLoginModel model)
        {
            return RedirectToAction("ListAllContent", "Disk");
        }
    }
}