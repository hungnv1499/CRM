using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Outsourcing.Data.Models;
using Outsourcing.Data;
using Outsourcing.Service;
using Labixa.Areas.Admin.ViewModel;
using AutoMapper;
using Outsourcing.Core.Framework.Controllers;

namespace Labixa.Areas.Admin.Controllers
{
    public class ProductAttributeController : Controller
    {
        #region Field
        readonly IProductAttributeService _productAttributeService;
        #endregion

        #region Ctor
        public ProductAttributeController(IProductAttributeService productAttributeService)
        {
            _productAttributeService = productAttributeService;
        }
        #endregion

        public ActionResult Index()
        {
            var productAttributes = _productAttributeService.GetProductAttributes();
            return View(model: productAttributes);
        }

        public ActionResult Create()
        {
            var productAttribute = new ProductAttributeFormModel();
            return View(productAttribute);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult Create(ProductAttributeFormModel newProductAttri, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                ProductAttribute productAttribute = Mapper.Map<ProductAttributeFormModel, ProductAttribute>(newProductAttri);
                _productAttributeService.CreateProductAttribute(productAttribute);
                return continueEditing ? RedirectToAction("Edit", "ProductAttribute", new { productAttriId = productAttribute.Id })
                                   : RedirectToAction("Index", "ProductAttribute");
            }
            else
            {
                return View("Create", newProductAttri);
            }
        }


        [HttpGet]
        public ActionResult Edit(int productAttriId)
        {
            var productAttribute = _productAttributeService.GetProductAttributeById(productAttriId);
            ProductAttributeFormModel productAttriFormModel = Mapper.Map<ProductAttribute, ProductAttributeFormModel>(productAttribute);
            return View(model: productAttriFormModel);
        }

                [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult Edit(ProductAttributeFormModel productAttriToEdit, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                ProductAttribute productAttribute = Mapper.Map<ProductAttributeFormModel, ProductAttribute>(productAttriToEdit);
                _productAttributeService.EditProductAttribute(productAttribute);
                return continueEditing ? RedirectToAction("Edit", "ProductAttribute", new { productAttriId = productAttribute.Id })
                                   : RedirectToAction("Index", "ProductAttribute");
            }
            else
            {
                return View("Edit", productAttriToEdit);
            }
        }

        public ActionResult Delete(int productAttriId)
        {
            _productAttributeService.DeleteProductAttribute(productAttriId);
            return RedirectToAction("Index");
        }
    }
}
