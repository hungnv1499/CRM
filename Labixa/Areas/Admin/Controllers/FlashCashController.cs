using System;
using System.Collections.Generic;
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
using Labixa.Helpers;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using Outsourcing.Service.APIController;

namespace Labixa.Areas.Admin.Controllers
{
    public partial class FlashCashController : BaseController
    {
        #region Field

        readonly IFlashCashService _FlashCashService;
        readonly ISubjectService _SubjectService;

        #endregion
        public FlashCashController(IFlashCashService FlashCashService, ISubjectService SubjectService)
        {
            _FlashCashService = FlashCashService;
            _SubjectService = SubjectService;
        }

        public ActionResult Index()
        {
         
            var list = _FlashCashService.GetFlashCashs().ToList();
            return View(model: list);
        }

        public ActionResult Create()
        {
            var listSubject = _SubjectService.GetSubjects().ToSelectListItems(-1);
            var list = new FlashCashFormModel { ListSubject = listSubject };
            return View(list);
        }
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(FlashCashFormModel newFlashCash, bool continueEditing, String CreateDate, HttpPostedFileBase SoundFile)
        {
            if (ModelState.IsValid)
            {
                if (SoundFile != null && SoundFile.ContentLength > 0)
                {
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Sound"),
                                                   Path.GetFileName(SoundFile.FileName));
                        newFlashCash.Sound = @"~/Sound/" + SoundFile.FileName;
                        SoundFile.SaveAs(path);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                else { newFlashCash.Sound = @"~/Sound/"; }
                //
                newFlashCash.CreateDate = DateTime.Parse(CreateDate);
                var item = Mapper.Map<FlashCashFormModel, FlashCash>(newFlashCash);
                _FlashCashService.CreateFlashCash(item);
                return continueEditing ? RedirectToAction("Edit", "FlashCash", new { id = item.Id })
                                    : RedirectToAction("Index", "FlashCash");
            }
            else
            {
                return View("Create", newFlashCash);
            }
        }

        public ActionResult Edit(int id)
        {
            var flashCash = _FlashCashService.GetFlashCashById(id);
            FlashCashFormModel flashCashFormModel = Mapper.Map<FlashCash, FlashCashFormModel>(flashCash);
            flashCashFormModel.ListSubject = _SubjectService.GetSubjects().ToSelectListItems(-1);
            return View(model: flashCashFormModel);  
        }
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(FlashCashFormModel obj, bool continueEditing,String CreateDate, HttpPostedFileBase SoundFile, String Sound)
        {
            if (ModelState.IsValid)
            {
                if (SoundFile != null && SoundFile.ContentLength > 0)
                {
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Sound"),
                                                   Path.GetFileName(SoundFile.FileName));
                        obj.Sound = @"~/Sound/" + SoundFile.FileName;
                        SoundFile.SaveAs(path);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }else
                {
                    obj.Sound = Sound;
                }
                FlashCash item = Mapper.Map<FlashCashFormModel, FlashCash>(obj);
                item.CreateDate = DateTime.Parse(CreateDate);
                _FlashCashService.EditFlashCash(item);
                return continueEditing ? RedirectToAction("Edit", "FlashCash", new { id = item.Id })
                    : RedirectToAction("Index", "FlashCash");
            }
            else
                return View("Edit", obj);
        }
        public ActionResult Delete(int id)
        {
            var item = _FlashCashService.GetFlashCashById(id);
            item.IsDelete = true;
            _FlashCashService.EditFlashCash(item);
            return RedirectToAction("Index", "FlashCash");
        }
    }
}

