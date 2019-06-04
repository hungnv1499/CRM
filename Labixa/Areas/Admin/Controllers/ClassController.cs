using AutoMapper;
using Labixa.Areas.Admin.ViewModel;
using Outsourcing.Core.Extensions;
using Outsourcing.Core.Framework.Controllers;
using Outsourcing.Data.Models;
using Outsourcing.Service;
using Outsourcing.Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Areas.Admin.Controllers
{
    public partial class ClassController : BaseController
    {
        #region Field
        readonly IClassService classService;
        readonly IClassUserMappingService classUserMappingService;
        readonly IUserFlashCashService userService;
        #endregion
        public ClassController(IClassService classService, IUserFlashCashService userService, IClassUserMappingService classUserMappingService)
        {
            this.classService = classService;
            this.userService = userService;
            this.classUserMappingService = classUserMappingService;
        }
        public ActionResult Index()
        {
            var list = classService.GetClasses().ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            var list = classService.GetClasses().ToSelectListItems(-1);
            var listClass = new ClassFormModel { ListClass = list };
            return View(listClass);
        }
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(ClassFormModel newClass, bool continueEditing, String CreateDate)
        {
            if (ModelState.IsValid)
            {
                var item = Mapper.Map<ClassFormModel, Class>(newClass);
                var itemtemp = new Class()
                {
                    ClassName = newClass.ClassName,
                    IsActive = newClass.IsActive,
                    Id = newClass.Id,
                    CreateDate = newClass.CreateDate,
                    //newCode.DateCreated = DateTime.Parse(DateCreated);
                    temp1 = newClass.temp1,
                    temp2 = newClass.temp2,
                    temp3 = newClass.temp3,
                    temp4 = newClass.temp4,
                    temp5 = newClass.temp5,
                    IsDelete = newClass.IsDelete

                };
                newClass.CreateDate = DateTime.Parse(CreateDate);
                classService.CreateClass(item);
                return continueEditing ? RedirectToAction("Edit", "Class", new { id = item.Id })
                                    : RedirectToAction("Index", "Class");
            }
            else
            {
                return View("Create", newClass);
            }
        }
        public ActionResult Edit(int id)
        {
            var item = classService.GetClassById(id);
            var obj = Mapper.Map<Class, ClassFormModel>(item);
            if (obj != null)
            {
                return View(obj);
            }
            return RedirectToAction("Index", "Class");
        }
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(ClassFormModel obj, bool continueEditing, String CreateDate)
        {
            if (ModelState.IsValid)
            {
                Class item = Mapper.Map<ClassFormModel, Class>(obj);
                //if (obj.SubjectName != null)
                //{
                //    item.SubjectName = StringConvert.ConvertShortName(obj.Name);
                //}
                item.CreateDate = DateTime.Parse(CreateDate);
                classService.EditClass(item);
                return continueEditing ? RedirectToAction("Edit", "Class", new { id = item.Id })
                    : RedirectToAction("Index", "Class");
            }
            else
                return View("Edit", obj);
        }
        public ActionResult Delete(int id)
        {
            var item = classService.GetClassById(id);
            item.IsDelete = true;
            classService.EditClass(item);
            return RedirectToAction("Index", "Class");
        }
        public ActionResult Detail(int id)
        {
            var userMapping = classUserMappingService.GetInClass(id).ToList();
            var item = classService.GetClassById(id);
            var obj = Mapper.Map<Class, ClassFormModel>(item);
            var x = Enum.GetValues(typeof(UserStatusEnum)).Cast<UserStatusEnum>().ToList();
            Dictionary<int, UserStatusEnum> list = new Dictionary<int, UserStatusEnum>();
            for (int i = 0; i < x.Count(); i++)
            {
                list.Add(i + 1, x[i]);
            }
            ViewBag.ListStatus = list;
            
            if (obj != null)
            {
                obj.ListClassUserMapping = userMapping;
                return View(obj);
            }
            return RedirectToAction("Index", "Class");
        }
        public ActionResult AddUser(int Id)
        {
            var classes = classService.GetClassById(Id);
            ViewBag.ClassId = classes.Id;
            if (classes != null)
            {
                var userMapping = classUserMappingService.GetInClass(Id).ToList();
                var listUser = userService.GetUserNotInClass(userMapping).ToList();

                return View(model: listUser);
            }
            return RedirectToAction("Detail", "Class");

        }
        public ActionResult UpdateUserClass(string id, string classId)
        {
            var cId = int.Parse(classId);
            ClassUserMapping classUser = new ClassUserMapping()
            {
                ClassId = cId,
                UserId = id,
                Status = (int)UserStatusEnum.Doing
            };
            classUserMappingService.Add(classUser);
            return RedirectToAction("AddUser", "Class", new { Id = cId });
        }

        public ActionResult DeleteUserFromClass(string id, int classId)
        {
            classUserMappingService.DeleteUserFromClass(id, classId);
            return RedirectToAction("Detail", "Class", new { Id = classId });
        }
        public ActionResult ChangeStatus(int id, string status)
        {
            var classUserMapping = classUserMappingService.GetById(id);
            int classId = classUserMapping.ClassId;
            if (classUserMapping != null)
            {
                int st = int.Parse(status);
                classUserMapping.Status = st;
                classUserMappingService.Update(classUserMapping);
                return RedirectToAction("Detail", "Class", new { Id = classId });
            }
            return View();
        }
    }
}