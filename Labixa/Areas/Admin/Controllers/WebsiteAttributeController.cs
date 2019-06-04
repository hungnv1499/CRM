using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Labixa.Areas.Admin.ViewModel;
using Labixa.Areas.Admin.ViewModel.WebsiteAtribute;
using Outsourcing.Core.Framework.Controllers;
using Outsourcing.Data.Models;
using Outsourcing.Service;

namespace Labixa.Areas.Admin.Controllers
{
    public class WebsiteAttributeController : Controller
    {

        #region Field
        readonly IWebsiteAttributeService _websiteAttributeService;
        #endregion

        #region Ctor
        public WebsiteAttributeController(IWebsiteAttributeService websiteAttributeService)
        {
            _websiteAttributeService = websiteAttributeService;
        }
        #endregion
        //
        // GET: /Admin/WebsiteAttribute/
        public ActionResult Index()
        {
            return RedirectToAction("Manage");
        }
        public ActionResult Manage()
        {
            var list = _websiteAttributeService.GetWebsiteAttributes().ToList().GroupBy(w => w.Type).Select(w => new WebsiteAttributeManageModel
            {
                Type = w.Key,
                WebsiteAttributes = w.ToList()
            });
            return View(model: list.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(WebsiteAttributeFormModel model)
        {
            if (ModelState.IsValid)
            {
                WebsiteAttribute websiteAttribute = Mapper.Map<WebsiteAttributeFormModel, WebsiteAttribute>(model);
                _websiteAttributeService.CreateWebsiteAttribute(websiteAttribute);
                return RedirectToAction("Index", "WebsiteAttribute");
            }
            else
            {
                return View("Create", model);
            }
        }
        public ActionResult Edit(int id)
        {
            var websiteAttribute = _websiteAttributeService.GetWebsiteAttributeById(id);
            WebsiteAttributeFormModel model = Mapper.Map<WebsiteAttribute, WebsiteAttributeFormModel>(websiteAttribute);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index", "WebsiteAttribute");
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult Edit(WebsiteAttributeFormModel model, bool continueEditing)
        {

            WebsiteAttribute websiteAttribute = Mapper.Map<WebsiteAttributeFormModel, WebsiteAttribute>(model);

            _websiteAttributeService.EditWebsiteAttribute(websiteAttribute);

            return continueEditing ? RedirectToAction("Edit", "WebsiteAttribute", new { id = websiteAttribute.Id })
                                    : RedirectToAction("Index", "WebsiteAttribute");
        }
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult EditAll(List<WebsiteAttributeManageModel> model)
        {
            foreach (var type in model)
            {
                foreach (var attribute in type.WebsiteAttributes)
                {
                    _websiteAttributeService.EditWebsiteAttribute(attribute);
                }
            }
            return RedirectToAction("Manage", "WebsiteAttribute");
        }
        public ActionResult Delete(int id)
        {
            _websiteAttributeService.DeleteWebsiteAttribute(id);
            return RedirectToAction("Index", "WebsiteAttribute");
        }
	}

}