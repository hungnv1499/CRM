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
using Outsourcing.Service.APIController;
using System.Drawing;
using System.IO;
using Outsourcing.Service.Enums;

namespace Labixa.Areas.Admin.Controllers
{
    public partial class UserController : BaseController
    {
        #region Field

        readonly IUserFlashCashService _UserFlashCashService;
        readonly IClassService classService;
        readonly IClassUserMappingService classUserMappingService;

        #endregion

        #region Ctor
        public UserController(IUserFlashCashService UserFlashCashService, IClassService classService, IClassUserMappingService classUserMappingService)
        {
            _UserFlashCashService = UserFlashCashService;
            this.classService = classService;
            this.classUserMappingService = classUserMappingService;
        }
        #endregion

        public ActionResult Index()
        {


            var UserFlashCashs = _UserFlashCashService.GetUserFlashCashs().ToList();
            return View(model: UserFlashCashs);
        }

        public ActionResult Create()
        {
            var listUser = new List<SelectListItem>();
            var list = new UserFlashCashFormModel { ListUser = listUser };
            return View(list);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult Create(UserFlashCashFormModel newUssers, bool continueEditing, string DateOfBirth, string Password, HttpPostedFileBase ImageFile)
        {
            newUssers.CreatedDate = DateTime.Now;
           
            if (ModelState.IsValid)
            {
                byte[] xByte;
                if (ImageFile != null)
                {
                    Image img = Image.FromStream(ImageFile.InputStream, true, true);
                    ImageConverter _imageConverter = new ImageConverter();
                    xByte = (byte[])_imageConverter.ConvertTo(img, typeof(byte[]));
                }
                else xByte = null;
                    newUssers.PasswordHash = Password;
                    //newUssers.UserName = newUssers.UserName;
                if (DateOfBirth != null) newUssers.DoB = DateTime.Parse(DateOfBirth);
                else DateOfBirth = DateTime.Now.ToString();
                    //Mapping to domain
                    AspNetUser usser = Mapper.Map<UserFlashCashFormModel, AspNetUser>(newUssers);

                    var result = _UserFlashCashService.CreateUserFlashCash(usser, xByte);
                    if (result)
                    return continueEditing ? RedirectToAction("Edit", "User", new { id = usser.Id })
                                      : RedirectToAction("Index", "User");
                    else return View("Create", newUssers);
            }
            else
            {
                return View("Create", newUssers);
            }
        }

        //
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            var user = _UserFlashCashService.GetUserFlashCashById(Id);
            UserFlashCashFormModel UserFlashCashFormModel = Mapper.Map<AspNetUser, UserFlashCashFormModel>(user);
            string url = UserAPIService.url + UserFlashCashFormModel.Avatar;
            ViewBag.Url = url;
            return View(model: UserFlashCashFormModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult Edit(UserFlashCashFormModel userToEdit, bool continueEditing, String Password, String DoB, String UrlImage)
        {
            if (ModelState.IsValid)
            {
                //Mapping to domain
                userToEdit.DoB = DateTime.Parse(DoB);
                userToEdit.Avatar = UrlImage;
                AspNetUser user = Mapper.Map<UserFlashCashFormModel, AspNetUser>(userToEdit);
                _UserFlashCashService.EditUserFlashCash(user);
                return continueEditing ? RedirectToAction("Edit", "User", new { id = user.Id })
                                 : RedirectToAction("Index", "User");
            }
            else
            {
                //userToEdit.ListRole = _RoleService.GetListRole().ToSelectListItems(-1);
                return View("Edit", userToEdit);
            }
        }



        public ActionResult Delete(string Id)
        {
            _UserFlashCashService.DeleteUserFlashCash(Id);
            return RedirectToAction("Index");
        }
        public ActionResult Detail(string Id)
        {

            var classMapping = classUserMappingService.GetInUser(Id).ToList();
            var userDetail = _UserFlashCashService.GetUserFlashCashById(Id);
            var obj = Mapper.Map<AspNetUser, UserFlashCashFormModel>(userDetail);
            var x = Enum.GetValues(typeof(UserStatusEnum)).Cast<UserStatusEnum>().ToList();
            Dictionary<int, UserStatusEnum> list = new Dictionary<int, UserStatusEnum>();
            for (int i = 0; i < x.Count(); i++)
            {
                list.Add(i+1, x[i]);
            }
            ViewBag.ListStatus = list;
            obj.ListClassUserMapping = classMapping;
            if (obj != null)
            {
                return View(obj);
            }
            return RedirectToAction("Index", "Class");
        }
        public ActionResult AddClass(string Id)
        {
            var user = _UserFlashCashService.GetUserFlashCashById(Id);
            ViewBag.UserId = Id;
            if (user != null)
            {
                var classMapping = classUserMappingService.GetInUser(Id).ToList();
                var listClass = classService.GetClassNotUser(classMapping).ToList();

                return View(model: listClass);
            }
            return RedirectToAction("Detail", "User");
        }
        public ActionResult UploadClassUser(string Id, string UserId)
        {
            var cId = int.Parse(Id);
            ClassUserMapping classUser = new ClassUserMapping()
            {
                ClassId = cId,
                UserId = UserId,
                Status = (int)UserStatusEnum.Doing,
            };
            classUserMappingService.Add(classUser);
            return RedirectToAction("AddClass", "User", new { Id = UserId });
        }

        public ActionResult DeleteUserFromClass(string id, int classId)
        {
            classUserMappingService.DeleteUserFromClass(id, classId);
            return RedirectToAction("Detail", "User", new { Id = id });
        }
        public ActionResult ChangeStatus(int id, string status)
        {
            var classUserMapping = classUserMappingService.GetById(id);
            string userId = classUserMapping.AspNetUser.Id;
            if (classUserMapping != null)
            {
                int st = int.Parse(status);
                classUserMapping.Status = st;
                classUserMappingService.Update(classUserMapping);
                return RedirectToAction("Detail", "User", new { Id = userId });
            }
            return View();
        }
    }
}