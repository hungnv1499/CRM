using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Outsourcing.Data.Models;

namespace Labixa.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Admin/Image/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Picture obj)
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Picture obj)
        {
            return View();
        }
        
	}
}