using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
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
           

            return View(new AccountLoginModel());
        }

        [HttpPost]
        public ActionResult LogIn(AccountLoginModel model)
        {
            var account = _readOnlyRepository.First<Account>(
                    x => x.Email == model.Email && x.Password == model.Password);



            if (account != null)
            {

                List<string> roles = account.Roles.Select(x => x.Name).ToList();
                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                SetAuthenticationCookie(model.Email, roles);
                return RedirectToAction("Index"); //redirect to wanted view.
            }

            Error("Email and/or password incorrect");
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new AccountInputModel());
        }

        [HttpPost]
        public ActionResult Register(AccountInputModel model)
        {
            var account = Mapper.Map<AccountInputModel, Account>(model);
            account.IsConfirm = false;
            account.HashConfirmation = CreateHastConfirmationString();
            account = _writeOnlyRepository.Create(account);

            //enviar email para confirmar
            // si paso el email
            return View();
        }

        private string CreateHastConfirmationString()
        {
            return "";
        }

        [HttpGet]
        public ActionResult ConfirmAccount(string hash)
        {
            Account account = _readOnlyRepository.Query<Account>(x => x.HashConfirmation == hash).FirstOrDefault();
            account.IsConfirm = true;
            _writeOnlyRepository.Update(account);
            return null;
        }

    }
}