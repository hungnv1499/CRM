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
    [FluentValidation.Attributes.Validator(typeof(BlogValidator))]
    public class BlogFormModel
    {
        
        public BlogFormModel()
        {
            ListCategory = new List<SelectListItem>();
        }

        [Key]
        public int Id { get; set; }
        [DisplayName(@"Tiêu đề")]
        public string Title { get; set; }
         [DisplayName(@"Title")]
        public string TitleEng { get; set; }
        /// <summary>
        /// URL  SEO friendly
        /// </summary>
        [DisplayName(@"Đường dẫn")]
        public string Slug { get; set; }

        [DisplayName(@"Thẻ meta từ khóa")]
        public string MetaKeywords { get; set; }

        [DisplayName(@"Thẻ meta Trang")]
        public string MetaTitle { get; set; }

        [DisplayName(@"Thẻ meta Mô tả")]
        public string MetaDescription { get; set; }

        [DisplayName(@"Hình ảnh")]
        public string BlogImage { get; set; }

        [DisplayName(@"Mô tả ")]
        public string Description { get; set; }
        [DisplayName(@"Nội Dung")]
          public string Content { get; set; }
          [DisplayName(@"Desciption ")]
          public string DescriptionEng { get; set; }
          [DisplayName(@"Content")]
          public string ContentEng { get; set; }
        [DisplayName(@"Hiển thị")]
        public bool IsAvailable { get; set; }

        //Get or set the picture of blog
        //Later
        [DisplayName(@"Hình ảnh")]
        //
        public int PictureId { get; set; }

        [DisplayName(@"Vị Trí")]
        public int Position { get; set; }

        [DisplayName(@"Danh mục")]
        public int BlogCategoryId { get; set; }

        [DisplayName(@"Danh mục")]
        public IEnumerable<SelectListItem> ListCategory { get; set; }
    }
    public class BlogValidator : AbstractValidator<BlogFormModel>
    {
        public BlogValidator()
        {
            // RuleFor(x => x.Title).NotNull().WithMessage("fffffff");
            RuleFor(x => x.BlogCategoryId).NotNull().WithMessage("Danh Mục Không Được Để Trống");
            //RuleFor(x => x.Description).NotNull().WithMessage("Mô Tả Không Được Để Trống");

        }
    }
}