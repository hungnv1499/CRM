using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labixa.Models;
using Outsourcing.Service;
using Outsourcing.Data.Models;
using PagedList;
using Labixa.ViewModels;
using Labixa.Helpers;
namespace Labixa.Controllers
{

    public class HomeController : BaseHomeController
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productcategoryService;
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IWebsiteAttributeService _websiteAttributeService;
        private readonly IStaffService _staffService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductRelationshipService _productRelationshipService;



        public HomeController(IProductService productService, IBlogService blogService,
            IWebsiteAttributeService websiteAttributeService, IBlogCategoryService blogCategoryService,
            IStaffService staffService, IProductAttributeMappingService productAttributeMappingService,
            IProductRelationshipService productRelationshipService, IProductCategoryService productcategoryService)
        {
            this._productService = productService;
            this._blogService = blogService;
            this._websiteAttributeService = websiteAttributeService;
            this._blogCategoryService = blogCategoryService;
            this._staffService = staffService;
            this._productAttributeMappingService = productAttributeMappingService;
            this._productRelationshipService = productRelationshipService;
            this._productcategoryService = productcategoryService;
        }
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.productHome = _productService.Get3ProductHome();// lay 3 sp dau tien
            model.productHomeV2 = _productService.Get3ProductHomeV2();// lay ba sp cuoi cung
            model.imageHome1 = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Name.Equals("Banner1"));
            model.imageHome2 = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Name.Equals("Banner2"));
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }


        #region
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult getHeader()
        {
            var list = _productcategoryService.GetProductCategories();
            return PartialView("_Header", list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult about_us()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Tours()
        {
            return View();
        }
        public ActionResult DetailTour()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(string Name, string Yahoo, string Rename, string Phone, string Description)
        {
          
            Staff obj = new Staff();
            obj.Deleted = false;
            obj.Description = Description;
            obj.Name = Name;
            //thay thế cho email
            obj.Yahoo = Yahoo;
            //thay thế cho tiêu đề
            obj.Rename = Rename;
            obj.Phone = Phone;

            _staffService.CreateStaff(obj);
            ViewBag.Message = "Gửi tin nhắn thành công";
            return RedirectToAction("Contact", "Home");
        }


        #endregion
        #region[Multi Language]
        public ActionResult SetCulture(string slug)
        {
            // Validate input
            slug = CultureHelper.GetImplementedCulture(slug);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = slug;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = slug;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        #endregion
    }
}