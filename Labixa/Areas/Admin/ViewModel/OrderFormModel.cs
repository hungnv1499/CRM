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
    [FluentValidation.Attributes.Validator(typeof(OrderValidator))]
    public class OrderFormModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName(@"Tên khách hàng")]
        public string CustomerName { get; set; }

        [DisplayName(@"Địa chỉ")]
        public string CustomerAddress { get; set; }

        [DisplayName(@"Điện thoại")]
        public string CustomerPhone { get; set; }

        [DisplayName(@"Email")]
        public string CustomerEmail { get; set; }

        [DisplayName(@"Tổng Order")]
        public int OrderTotal { get; set; }

        [DisplayName(@"Tình trạng")]
        public bool Deleted { get; set; }

        [DisplayName(@"Ghi chú")]
        public string Note { get; set; }

    }
    public class OrderValidator : AbstractValidator<OrderFormModel>
    {
        public OrderValidator()
        {
            RuleFor(x => x.CustomerName).NotNull().WithMessage("Tên Khách Hàng Không Được Để Trống");
            RuleFor(x => x.CustomerAddress).NotNull().WithMessage("Địa Chỉ Không Được Để Trống");
            RuleFor(x => x.CustomerPhone).NotNull().WithMessage("Điện Thoại Không Được Để Trống");
            RuleFor(x => x.CustomerPhone).Length(10,12) .WithMessage("Số Điện Thoại Không Hợp Lệ (10 - 12 số)");
            RuleFor(x => x.CustomerEmail).NotNull().WithMessage("Email Không Được Để Trống");
        }
    }
}