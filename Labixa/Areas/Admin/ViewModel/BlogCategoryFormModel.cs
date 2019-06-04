using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Outsourcing.Data.Models;
using FluentValidation.Mvc;
using FluentValidation.Validators;
using FluentValidation;

namespace Labixa.Areas.Admin.ViewModel
{
    [FluentValidation.Attributes.Validator(typeof(BlogCategoryValidator))]
    public class BlogCategoryFormModel
    {
        public BlogCategoryFormModel()
        {
            ListCategory = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [DisplayName(@"Tên Danh Mục")]
        public string Name { get; set; }

        [DisplayName(@"Tình Trạng")]
        public bool Status { get; set; }

        [DisplayName(@"Vị Trí Đặt")]
        public int DisplayOrder { get; set; }

        [DisplayName(@"Trang Tĩnh")]
        public bool IsStaticPage { get; set; }

        [DisplayName(@"Danh Mục Cha")]
        public int? CategoryParentId { get; set; }

        public IEnumerable<SelectListItem> ListCategory { get; set; } 
    }
    public class BlogCategoryValidator : AbstractValidator<BlogCategoryFormModel>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Tên Không Được Để Trống");
           // RuleFor(x => x.Description).NotNull().WithMessage("Mô Tả Không Được Để Trống");
        }
    }
}