using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Outsourcing.Data.Models;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Areas.Admin.ViewModel
{
    [FluentValidation.Attributes.Validator(typeof(ClassValidator))]
    public class ClassFormModel
    {
        public ClassFormModel()
        {
            ListClass = new List<SelectListItem>();
            ListUser = new List<AspNetUser>();
            ListClassUserMapping = new List<ClassUserMapping>();


        }
        [Key]
        public int Id { get; set; }
        [DisplayName(@"ClassName")]
        public String ClassName { get; set; }
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
        public int Status { get; set; }
        public IEnumerable<SelectListItem> ListClass { get; set; }
        public List<AspNetUser> ListUser { get; set; }
        public List<ClassUserMapping> ListClassUserMapping { get; set; }



    }
    public class ClassValidator : AbstractValidator<ClassFormModel>
    {
        public ClassValidator()
        {
            RuleFor(x => x.ClassName).NotNull().WithMessage("ClassName không được để trống");
           

        }
    }
}