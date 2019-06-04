using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation.Mvc;
using FluentValidation.Validators;
using FluentValidation;

namespace Labixa.Areas.Admin.ViewModel
{
    [FluentValidation.Attributes.Validator(typeof(StaffValidator))]
    public class StaffFormModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Image { get; set; }

        public string Rename { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

        public bool Deleted { get; set; }

        public string Yahoo { get; set; }
        public string Skype { get; set; }
    }
    public class StaffValidator : AbstractValidator<StaffFormModel>
    {
        public StaffValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Tên Không Được Để Trống");
             RuleFor(x => x.Phone).NotNull().WithMessage("Điện Thoại Không Được Để Trống");
        }
    }
}