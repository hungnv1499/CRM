using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Mvc;
using FluentValidation.Validators;
using FluentValidation;

namespace Labixa.Areas.Admin.ViewModel
{

    [FluentValidation.Attributes.Validator(typeof(ProductAttributeValidator))]
    public class ProductAttributeFormModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName(@"Tên thuộc tính")]
        public string Name { get; set; }

        [DisplayName(@"Cách điều khiển")]
        public string ControlType { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }
    }
    public class ProductAttributeValidator : AbstractValidator<ProductAttributeFormModel>
    {
        public ProductAttributeValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Tên Không Được Để Trống");
            RuleFor(x => x.Description).NotNull().WithMessage("Mô Tả Không Được Để Trống");
        }
    }
}