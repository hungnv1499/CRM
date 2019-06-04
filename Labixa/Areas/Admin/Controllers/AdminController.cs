using Microsoft.AspNet.Identity;
using Outsourcing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Areas.Admin.Controllers
{
    [Authorize]
    public  class AdminController : Controller
    {
        UserManager<ApplicationUser> userManager;
        public AdminController()
        {
            
        }
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword(string Id,string oldPass, string newPass)
        {
            Id= "c21a1169-1e5d-4aa7-9604-1595514608bc";
            oldPass = "123456";
            newPass = "labixa123";
                        userManager.ChangePassword(Id, oldPass, newPass);
            return View("Index");
        }
	}
}