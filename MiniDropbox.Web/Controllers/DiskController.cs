using System.Collections.Generic;
using System.Web.Mvc;
using Amazon;
using Amazon.S3.Model;
using BootstrapMvcSample.Controllers;
using FizzWare.NBuilder;
using MiniDropbox.Domain;
using MiniDropbox.Domain.Services;
using MiniDropbox.Web.Models;

namespace MiniDropbox.Web.Controllers
{
    public class DiskController : BootstrapBaseController
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public DiskController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var account = _readOnlyRepository.First<Account>(x => x.Email == User.Identity.Name);
            

            var diskContentList = Builder<DiskContentModel>.CreateListOfSize(10).Build();
            return View(diskContentList);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {
                var account = _readOnlyRepository.First<Account>(x => x.Email == User.Identity.Name);

                var client = AWSClientFactory.CreateAmazonS3Client();
                var putObjectRequest = new PutObjectRequest
                    {
                        BucketName = account.BucketName,
                        Key = file.FileName,
                        InputStream = file.InputStream
                    };
                
                client.PutObject(putObjectRequest);
                //save to database here

                Success("The file " + file.FileName + " was uploaded.");
                return RedirectToAction("Index");
            }
            Error("There was a problem uploading the file.");
            return View("Upload");
        }
    }
}