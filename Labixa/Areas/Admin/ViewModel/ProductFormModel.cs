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
    [FluentValidation.Attributes.Validator(typeof(ProductValidator))]

    public class ProductFormModel
    {
        public ProductFormModel()
        {
            ListProductCategory = new List<SelectListItem>();
            ListProducts = new List<SelectListItem>();
        }

        [Key]
        public int Id { get; set; }

        [DisplayName(@"Tên sản phẩm")]
        public string Name { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Nội dung")]
        public string Content { get; set; }

        [DisplayName(@"Hiển thị trên trang chủ")]
        public bool IsHomePage { get; set; }

        [DisplayName(@"Công bố")]
        public bool IsPublic { get; set; }

        [DisplayName(@"Giá hiện tại của sản phẩm")]
        public int Price { get; set; }
        [DisplayName(@"Giá cũ sản phẩm")]
        public int OldPrice { get; set; }
        [DisplayName(@"Title")]
        public string NameEng { get; set; }
        [DisplayName(@"Desc English")]
        public string DescEng { get; set; }
        [DisplayName(@"Content")]
        public string ContentEng { get; set; }
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
        [DisplayName(@"Danh mục")]
        public int ProductCategoryId { get; set; }

        [DisplayName(@"Danh mục")]
        public IEnumerable<SelectListItem> ListProductCategory { get; set; }

        [DisplayName(@"Thuộc tính sản phẩm")]
        public ICollection<ProductAttributeMapping> ProductAttributeMappings { get; set; }

        [DisplayName(@"Hình ảnh sản phẩm")]
        public ICollection<ProductPictureMapping> ProductPictureMappings { get; set; }

        [DisplayName(@"Sản Phẩm")]
        public IEnumerable<SelectListItem> ListProducts { get; set; }

        [DisplayName(@"Vị Trí đặt")]
        public int Position { get; set; }

        [DisplayName(@"Tour Liên Quan 1 : ")]
        public int Id1 { get; set; }

        [DisplayName(@"Tour Liên Quan 2 : ")]
        public int Id2 { get; set; }

        [DisplayName(@"Tour Liên Quan 3 : ")]
        public int Id3 { get; set; }
    }
    public class ProductValidator : AbstractValidator<ProductFormModel>
    {
        public ProductValidator()
        {
            //RuleFor(x => x.Name).NotNull().WithMessage("Tên Không Được Để Trống");
            //RuleFor(x => x.Description).NotNull().WithMessage("Mô Tả Không Được Để Trống");
            //RuleFor(x => x.Price).NotNull().WithMessage("Giá Không Được Để Trống");
        }
    }
}