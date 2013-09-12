using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Amazon;
using Amazon.S3;
using Amazon.S3.IO;
using Amazon.S3.Model;
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
                var roles = new List<string>();
                string roleToAdd = "";
                roleToAdd = account.IsAdmin ? "Admin" : "User";
                roles.Add(roleToAdd);
                FormsAuthentication.SetAuthCookie(model.Email, false);
                SetAuthenticationCookie(model.Email, roles);
                return RedirectToAction("Index", "Disk");
            }

            Error("Email and/or password incorrect");
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login",new AccountLoginModel());
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
            account.BucketName = string.Format("mdp.{0}", Guid.NewGuid());
            account = _writeOnlyRepository.Create(account);

            //Create a bucket for the new user on AWS S3
            var client = AWSClientFactory.CreateAmazonS3Client();
            var newBucket = new PutBucketRequest {BucketName = account.BucketName};
            client.PutBucket(newBucket);

            Success("El usuario "+account.Email + " se ha registrado.");

            return RedirectToAction("LogIn");
        }

        public ActionResult Index()
        {
            return null;
        }
    }
}