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

namespace Labixa.Areas.Admin.Controllers
{
    public partial class SubjectController : BaseController
    {
        #region Field

        readonly ISubjectService _SubjectService;

        #endregion
        public SubjectController(ISubjectService SubjectService)
        {
            _SubjectService = SubjectService;
            

        }

        public ActionResult Index()
        {
            var list = _SubjectService.GetSubjects().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            var listSubject = _SubjectService.GetSubjects().ToSelectListItems(-1);
            var list = new SubjectFormModel { ListSubject = listSubject };
            return View(list);
        }
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(SubjectFormModel newSubject, bool continueEditing, String CreateDate)
        {
            if (ModelState.IsValid)
            {
                newSubject.CreateDate = DateTime.Parse(CreateDate);
                var item = Mapper.Map<SubjectFormModel, Subject>(newSubject);
                _SubjectService.CreateSubject(item);
                return continueEditing ? RedirectToAction("Edit", "Subject", new { id = item.Id })
                                    : RedirectToAction("Index", "Subject");
            }
            else
            {
                return View("Create", newSubject);
            }
        }

        public ActionResult Edit(int id)
        {
            var item = _SubjectService.GetSubjectById(id);

          
            SubjectFormModel obj = Mapper.Map<Subject, SubjectFormModel>(item);
            if (obj != null)
            {
                return View(obj);
            }
            return RedirectToAction("Index", "Subject");
        }
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(SubjectFormModel obj, bool continueEditing, String CreateDate)
        {
            if (ModelState.IsValid)
            {
                Subject item = Mapper.Map<SubjectFormModel, Subject>(obj);
                //if (obj.SubjectName != null)
                //{
                //    item.SubjectName = StringConvert.ConvertShortName(obj.Name);
                //}
                obj.CreateDate = DateTime.Parse(CreateDate);
                _SubjectService.EditSubject(item);
                return continueEditing ? RedirectToAction("Edit", "Subject", new { id = item.Id })
                    : RedirectToAction("Index", "Subject");
            }
            else
                return View("Edit", obj);
        }
        public ActionResult Delete(int id)
        {
            var item = _SubjectService.GetSubjectById(id);
            item.IsDelete = true;
            _SubjectService.EditSubject(item);
            return RedirectToAction("Index", "Subject");
        }
    }
}

