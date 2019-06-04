using FluentValidation;
using Outsourcing.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Areas.Admin.ViewModel
{
    [FluentValidation.Attributes.Validator(typeof(CodeActiveValidator))]
    public class CodeActiveFormModel
    {
        public CodeActiveFormModel()
        {
             ListCode = new List<SelectListItem>();
             ListSubject = new List<SelectListItem>();
            ListUserCodeMapping = new List<UserCodeMapping>();
        }
        [Key]
        public int Id { get; set; }
        [DisplayName(@"CodeName")]
        public String CodeName { get; set; }
        [DisplayName(@"Ngày hết hạn")]
        public DateTime ExpiredDate { get; set; }
        [DisplayName(@"Ngày tạo")]
        public DateTime DateCreated { get; set; }
        [DisplayName(@"Hiển thị")]
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }
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
        public int SubjectId { get; set; }

        public IEnumerable<SelectListItem> ListSubject { get; set; }

        public IEnumerable<SelectListItem> ListCode { get; set; }
        public List<UserCodeMapping> ListUserCodeMapping { get; set; }
    }
    public class CodeActiveValidator : AbstractValidator<CodeActiveFormModel>
    {
        public CodeActiveValidator()
        { 
            RuleFor(x => x.SubjectId).NotNull().WithMessage("subject không được để trống");
        }
    }
}