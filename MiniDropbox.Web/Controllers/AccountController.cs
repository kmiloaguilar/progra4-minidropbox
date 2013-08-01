using System.Web.Mvc;
using BootstrapMvcSample.Controllers;
using MiniDropbox.Domain;
using MiniDropbox.Domain.Services;
using MiniDropbox.Web.Models;

namespace MiniDropbox.Web.Controllers
{
    public class AccountController : BootstrapBaseController
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IWriteOnlyRepository _writeOnlyRepository;

        public AccountController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            var account = _readOnlyRepository.GetById<Account>(1);

            return View(new AccountLoginModel());
        }

        [HttpPost]
        public ActionResult LogIn(AccountLoginModel model)
        {
            return RedirectToAction("ListAllContent", "Disk");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new AccountInputModel());
        }
    }
}