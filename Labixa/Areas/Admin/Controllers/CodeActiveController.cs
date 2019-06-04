using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Labixa.Areas.Admin.ViewModel;
using Outsourcing.Core.Extensions;
using Outsourcing.Core.Framework.Controllers;
using Outsourcing.Data;
using Outsourcing.Data.Models;
using Outsourcing.Service;

namespace Labixa.Areas.Admin.Controllers
{
    public class CodeActiveController : BaseController
    {
        #region Field

        readonly ICodeActiveService codeActiveService;
        readonly ISubjectService subjectService;
        readonly IUserCodeMappingService userCodeMappingService;
        readonly IUserFlashCashService userFlashCashService;

        #endregion
        #region Constructor
        public CodeActiveController(ICodeActiveService codeActiveService, ISubjectService subjectService, IUserCodeMappingService userCodeMappingService
            , IUserFlashCashService userFlashCashService)
        {
            this.codeActiveService = codeActiveService;
            this.subjectService = subjectService;
            this.userCodeMappingService = userCodeMappingService;
            this.userFlashCashService = userFlashCashService;
        }
        #endregion

        // GET: /Admin/CodeActive/
        public ActionResult Index()
        {
            var listCodeActive = codeActiveService.GetCodeActives();
            return View(model: listCodeActive);
        }
        // GET: /Admin/CodeActive/Create
        public ActionResult Create()
        {
            var listSubject = subjectService.GetSubjects().ToSelectListItems(-1);
            var codeActive = new CodeActiveFormModel { ListSubject = listSubject };
            return View(codeActive);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult Create(CodeActiveFormModel newCode, bool continueEditing, String DateCreated, String ExpiredDate)
        {
            if (ModelState.IsValid)
            {
                newCode.DateCreated = DateTime.Parse(DateCreated);
                newCode.ExpiredDate = DateTime.Parse(ExpiredDate);
                //Mapping to domain
                CodeActive codeActive = Mapper.Map<CodeActiveFormModel, CodeActive>(newCode);
                //Create user
                
                codeActiveService.CreateCodeActive(codeActive);
                return continueEditing ? RedirectToAction("Edit", "CodeActive", new { CodeActiveId = codeActive.Id })
                                  : RedirectToAction("Index", "CodeActive");
            }
            else
            {
                newCode.ListSubject = subjectService.GetSubjects().ToSelectListItems(-1);
                return View("Create", newCode);
            }
        }

        //
        [HttpGet]
        public ActionResult Edit(int CodeActiveId)
        {
            var codeActive = codeActiveService.GetCodeActiveById(CodeActiveId);
            CodeActiveFormModel codeActiveFormModel = Mapper.Map<CodeActive, CodeActiveFormModel>(codeActive);
            codeActiveFormModel.ListSubject = subjectService.GetSubjects().ToSelectListItems(-1);
            return View(model: codeActiveFormModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult Edit(CodeActiveFormModel codeActiveToEdit, bool continueEditing, String ExpiredDate, String DateCreated)
        {
            if (ModelState.IsValid)
            {
                codeActiveToEdit.DateCreated = DateTime.Parse(DateCreated); 
                codeActiveToEdit.ExpiredDate = DateTime.Parse(ExpiredDate);
                //Mapping to domain
                CodeActive codeActive = Mapper.Map<CodeActiveFormModel, CodeActive>(codeActiveToEdit);

                codeActiveService.EditCodeActive(codeActive);
                return continueEditing ? RedirectToAction("Edit", "codeActive", new { CodeActiveId = codeActive.Id })
                                 : RedirectToAction("Index", "CodeActive");
            }
            else
            {
                codeActiveToEdit.ListSubject = subjectService.GetSubjects().ToSelectListItems(-1);
                return View("Edit", codeActiveToEdit);
            }
        }

        public ActionResult Detail(int CodeActiveId)
        {
            var code = codeActiveService.GetCodeActiveById(CodeActiveId);
            CodeActiveFormModel codeActiveFormModel = Mapper.Map<CodeActive, CodeActiveFormModel>(code);
            codeActiveFormModel.ListUserCodeMapping = userCodeMappingService.GetByCode(code.Id).ToList();
            codeActiveFormModel.ListSubject = subjectService.GetSubjects().ToSelectListItems(-1);
            return View(model: codeActiveFormModel);
        }
        public ActionResult AddUser(int codeActiveId)
        {
            ViewBag.CodeId = codeActiveId;
            var listUser = userFlashCashService.GetUserFlashCashs().ToList();
            return View(model: listUser);
        }
        public ActionResult UpdateUser(string Id, int codeActiveId)
        {
            var entity = userCodeMappingService.GetByCode(codeActiveId);
            if (entity.Count() == 0)
            {
                UserCodeMapping userCode = new UserCodeMapping()
                {
                    CodeId = codeActiveId,
                    UserId = Id,
                    AspNetUser = userFlashCashService.GetUserFlashCashById(Id),
                    CodeActive = codeActiveService.GetCodeActiveById(codeActiveId),
                };
                userCodeMappingService.Add(userCode);
                return RedirectToAction("Detail", "CodeActive", new { CodeActiveId = codeActiveId });
            }
            return RedirectToAction("Detail", "CodeActive", new { CodeActiveId = codeActiveId });
        }
        public ActionResult DeleteUserFromCode(int userCodeId, int codeId)
        {
            var entity = userCodeMappingService.GetById(userCodeId);
            if (entity != null)
            {
                userCodeMappingService.Delete(entity);
                return RedirectToAction("Detail", "CodeActive", new { CodeActiveId = codeId });
            }
            return RedirectToAction("Detail", "CodeActive", new { CodeActiveId = codeId });
        }
        public ActionResult Delete(int codeActiveId)
        {
            codeActiveService.DeleteCodeActive(codeActiveId);
            return RedirectToAction("Index");
        }
    }
}
