using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ElFinder;

namespace Labixa.Areas.Admin.Controllers
{
    public partial class FileController : Controller
    {
        private Connector _connector;

        public ActionResult Index()
        {
            return View();
        }

        public Connector Connector
        {
            get
            {
                if (_connector == null)
                {
                    FileSystemDriver driver = new FileSystemDriver();
                    var directory = new DirectoryInfo(Server.MapPath("~/images/uploaded"));
                    //var directory02 = new DirectoryInfo(Server.MapPath("../"));
                    DirectoryInfo thumbsStorage = directory;
                    //driver.AddRoot(new Root(new DirectoryInfo(@"D:\Images"))
                    //{
                    //    IsLocked = true,
                    //    IsReadOnly = true,
                    //    IsShowOnly = true,
                    //    ThumbnailsStorage = thumbsStorage,
                    //    ThumbnailsUrl = "Thumbnails/"
                    //});
                    //Root that display Elfinder
                    driver.AddRoot(new Root(directory, "/images/uploaded/")
                    {
                        //Alias = "Thư viện ảnh",
                        Alias = "/Uploaded",
                        StartPath = directory,
                        ThumbnailsStorage = thumbsStorage,
                        MaxUploadSizeInMb = 10,
                        ThumbnailsUrl = "/Admin/File/Thumbnails/",

                    });
                    _connector = new Connector(driver);
                }
                return _connector;
            }
        }
        /// <summary>
        /// Load folder to connector
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadFile()
        {
            return Connector.Process(this.HttpContext.Request);
        }
        public ActionResult SelectFile(List<String> values)
        {
            //var directory = new DirectoryInfo(Path.Combine(Directory.GetParent(Server.MapPath("")).Parent.FullName, "images/uploaded"));
            var rootUrl = "/images/uploaded";
            var returnlist = "";
            foreach (var file in values)
            {
                //@"\Images\" 
                var sliceString = Connector.GetFileByHash(file).FullName.Split(new string[] { rootUrl }, StringSplitOptions.None);
                //string[] sliceString = Regex.Split(Connector.GetFileByHash(file).FullName, @"\VC\");
                var url = sliceString[1].Replace(@"\", "/").Replace(@"\\", "/");
                returnlist += rootUrl + url + ";";
            }
            return Json(returnlist);
        }

        public ActionResult Thumbs(string tmb)
        {
            return Connector.GetThumbnail(Request, Response, tmb);
        }

        //public ActionResult Elfinder()
        //{
        //    return View("_Elfinder");
        //}
        public ActionResult GetImageFromElfinder(string elementId)
        {
            return View("_ElfinderTextBox",model:elementId);
        }
       
        public ActionResult BrowseFile()
        {
            return PartialView("_Elfinder");
        }
    }
}
