using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Labixa.Areas.Admin.ViewModel;
using Outsourcing.Service;
using Outsourcing.Data.Models;
using Outsourcing.Core.Common;
using Outsourcing.Core.Extensions;
using WebGrease.Css.Extensions;
using Outsourcing.Core.Framework.Controllers;

namespace Labixa.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
                        #region Field
        readonly IProductCategoryService _productCategoryService;
        #endregion

        #region Ctor
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        #endregion
        //
        // GET: /Admin/ProductCategory/
        public ActionResult Index()
        {
            var list = _productCategoryService.GetProductCategories().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            var listCategory = _productCategoryService.GetProductCategories().ToSelectListItems(-1);
            var list = new ProductCategoryFormModel {ListCategory = listCategory };
            return View(list);
        }
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(ProductCategoryFormModel obj, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                obj.Slug = StringConvert.ConvertShortName(obj.Name);
                var item = Mapper.Map<ProductCategoryFormModel, ProductCategory>(obj);
                _productCategoryService.CreateProductCategory(item);
                return continueEditing ? RedirectToAction("Edit", "ProductCategory", new { id = item.Id })
                                    : RedirectToAction("Index", "ProductCategory");
            }
            else
            {
                return View("Create", obj);
            }
        }

        public ActionResult Edit(int id)
        {
            var obj = _productCategoryService.GetProductCategoryById(id);
            var list2 = _productCategoryService.GetProductCategories().ToSelectListItems(int.Parse(obj.Position.ToString() == "" ? "0" : obj.Position.ToString()));
           
            var item = Mapper.Map<ProductCategory, ProductCategoryFormModel>(obj);
            item.ListCategory = list2;
            return View(item);
        }

        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(ProductCategoryFormModel obj, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                obj.Slug = StringConvert.ConvertShortName(obj.Name);
                var item = Mapper.Map<ProductCategoryFormModel, ProductCategory>(obj);
                _productCategoryService.EditProductCategory(item);
                return continueEditing ? RedirectToAction("Edit", "ProductCategory", new { id = item.Id })
                                   : RedirectToAction("Index", "ProductCategory");
            }
            return View("Edit", obj);
        }
        public ActionResult Delete(int id)
        {
            var item = _productCategoryService.GetProductCategoryById(id);
            item.Deleted = true;
            _productCategoryService.EditProductCategory(item);
            return RedirectToAction("Index", "ProductCategory");
        }
	}
}