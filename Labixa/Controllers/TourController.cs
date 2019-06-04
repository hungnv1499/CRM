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

namespace Labixa.Controllers
{
    public class TourController : BaseHomeController
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productcategoryService;
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IWebsiteAttributeService _websiteAttributeService;
        private readonly IStaffService _staffService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductRelationshipService _productRelationshipService;



        public TourController(IProductService productService, IBlogService blogService,
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
        //
        // GET: /Tour/
        public ActionResult Index()
        {
            #region [get ID category]
            List<int> listId = new List<int>();
            var idtour = _productcategoryService.GetProductCategories().Where(p => p.Name.ToLower().Equals("tour")).FirstOrDefault().Id;
            var listlevel1 = _productcategoryService.GetProductCategories().Where(p=>p.Position==idtour).ToList();
            listId.Add(idtour);
            foreach (var item in listlevel1)
            {
                listId.Add(item.Id);
                var listlevel2 = _productcategoryService.GetProductCategories().Where(p => p.Position == item.Id);
                foreach (var item2 in listlevel2)
                {
                    listId.Add(item2.Id);
                }
            }
            #endregion
            List<Product> listProduct = new List<Product>();
            foreach (var idcate in listId)
            {
                var temp = _productService.GetAllProducts().Where(p => p.ProductCategoryId == idcate);
                foreach (var product in temp)
                {
                    listProduct.Add(product);
                }
            }
            return View(listProduct);
        }
        public ActionResult categoryTour(int id)
        {
            List<int> listCate = new List<int>();
            listCate.Add(id);
            var list1 = _productcategoryService.GetProductCategories().Where(p => p.Position == id);
            foreach (var item in list1)
            {
                listCate.Add(item.Id);
            }
            List<Product> listProduct = new List<Product>();
            foreach (var item in listCate)
            {
                List<Product> list = _productService.GetAllProducts().Where(p => p.ProductCategoryId == item).ToList();
                listProduct.AddRange(list);
            }
            return View(listProduct);
        }
        public ActionResult detailTour(int id)
        {
            var product = _productService.GetProductById(id);
            return View(product);
        }
        public ActionResult detailService(int id)
        {
            var product = _productService.GetProductService(id);
            return View(product);
        }
	}
}