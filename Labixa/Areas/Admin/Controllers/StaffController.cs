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
    public class StaffController : Controller
    {
                #region Field
        readonly IStaffService _staffService;
        #endregion

        #region Ctor
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        #endregion
        //
        // GET: /Admin/Staff/
        public ActionResult Index()
        {
            var list = _staffService.GetStaffs();
            
            return View(list);
        }
        public ActionResult Create()
        {
            var model = new StaffFormModel();
            return View(model);
        }
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(StaffFormModel obj, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                obj.Deleted = false;
                if (obj.Name != null)
                {
                    obj.Rename = StringConvert.ConvertShortName(obj.Name);
                }
                Staff item = Mapper.Map<StaffFormModel, Staff>(obj);
                _staffService.CreateStaff(item);
                return continueEditing ? RedirectToAction("Edit", "Staff", new { id = item.Id })
                                 : RedirectToAction("Index", "Staff");
            }
            else return View("Create", obj); 
        }
        public ActionResult Edit(int id)
        {
            var item = _staffService.GetStaffById(id);
            StaffFormModel obj = Mapper.Map<Staff, StaffFormModel>(item);
            if (obj!=null)
            {
                return View(obj);
            }
            return RedirectToAction("Index", "Staff");
        }
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(StaffFormModel obj, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                Staff item = Mapper.Map<StaffFormModel, Staff>(obj);
                if (obj.Name != null)
                {
                    item.Rename = StringConvert.ConvertShortName(obj.Name);
                }
                _staffService.EditStaff(item);
                return continueEditing ? RedirectToAction("Edit", "Staff", new { id = item.Id })
                    : RedirectToAction("Index", "Staff");
            }
            else
            return View("Edit", obj);
        }
        public ActionResult Delete(int id)
        {
            _staffService.DeleteStaff(id);
            return RedirectToAction("Index", "Staff");
        }
	}
}