using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labixa;
using Outsourcing.Data.Models;
using FluentValidation.Mvc;
using FluentValidation.Validators;
using FluentValidation;
using Labixa.App_Data;
namespace Labixa.Areas.Admin.ViewModel
{
    [FluentValidation.Attributes.Validator(typeof(UserValidator))]
    public class UserFlashCashFormModel
    {
        public UserFlashCashFormModel()
        {
            ListUser = new List<SelectListItem>();
            ListClass = new List<Class>();
            ListClassUserMapping = new List<ClassUserMapping>();

        }
        [Key]
        public string Id { get; set; }
        [DisplayName(@"First name")]
        public string FirstName { get; set; }
        [DisplayName(@"Last name")]
        public string LastName { get; set; }
        [DisplayName(@"Phone Number")]
        //username là sdt 
        public string UserName { get; set; }
        [DisplayName(@"Mật khẩu")]
        public String PasswordHash { get; set; }
        [DisplayName(@"Số điện thoại")]
        public String PhoneNumber { get; set; }
        [DisplayName(@"Email")]
        public String Email { get; set; }
        [DisplayName(@"DayOfBirth")]
        public DateTime DoB { get; set; }
        [DisplayName(@"Avatar")]
        public string Avatar { get; set; }
        [DisplayName(@"Công việc")]
        public string Job { get; set; }
        public DateTime CreatedDate { get; set;}
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [DisplayName(@"Edit Avatar")]
        public string EditAvatar { get; set; }
        public IEnumerable<SelectListItem> ListUser { get; set; }
        public List<Class> ListClass { get; set; }
        public List<ClassUserMapping> ListClassUserMapping { get; set; }
        


    }
    public class UserValidator : AbstractValidator<UserFlashCashFormModel>
    {
        public UserValidator()
        {
            // RuleFor(x => x.Title).NotNull().WithMessage("fffffff");
            //RuleFor(x => x.Id).NotNull().WithMessage("role không được để trống");
            //RuleFor(x => x.Description).NotNull().WithMessage("Mô Tả Không Được Để Trống");

        }
    }
}