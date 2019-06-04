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
    [FluentValidation.Attributes.Validator(typeof(SubjectValidator))]
    public class SubjectFormModel
    {

        public SubjectFormModel()
        {
            ListSubject = new List<SelectListItem>();
            //CreateDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [DisplayName(@"SubjectName")]
        public String SubjectName { get; set; }
        public DateTime CreateDate { get; set; }
        [DisplayName(@"Hiển Thị")]
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        [DisplayName(@"Nội dung 1")]
        public String temp1 { get; set; }
        [DisplayName(@"Nội dung 2")]
        public String temp2 { get; set; }
        [DisplayName(@"Nội dung 3")]
        public String temp3 { get; set; }
        [DisplayName(@"Nội dung 4")]
        public String temp4 { get; set; }
        [DisplayName(@"Nội dung 5")]
        public String temp5 { get; set; }


      

        public IEnumerable<SelectListItem> ListSubject { get; set; }
    }
    public class SubjectValidator : AbstractValidator<SubjectFormModel>
    {
        public SubjectValidator()
        {
            // RuleFor(x => x.Title).NotNull().WithMessage("fffffff");
            RuleFor(x => x.SubjectName).NotNull().WithMessage("SubjectName không được để trống");
            //RuleFor(x => x.Description).NotNull().WithMessage("Mô Tả Không Được Để Trống");

        }
    }
}