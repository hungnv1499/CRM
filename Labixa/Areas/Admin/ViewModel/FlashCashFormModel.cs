using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Areas.Admin.ViewModel
{
    [FluentValidation.Attributes.Validator(typeof(FlashCashValidator))]
    public class FlashCashFormModel
    {

        public FlashCashFormModel()
        {
            ListFlashCash = new List<SelectListItem>();
            ListSubject = new List<SelectListItem>();
        }
        [Key]
        public int Id { get; set; }
        [DisplayName(@"FlashCashName")]
        public string FlashCarhName { get; set; }
        [DisplayName(@"FlashCardAnswer")]
        public string FlashCardAnswer { get; set; }
        [DisplayName(@"CreateDate")]
        public System.DateTime CreateDate { get; set; }
        [DisplayName(@"Description")]
        public string Description { get; set; }
        [DisplayName(@"DescriptionEng")]
        public string DescriptionEng { get; set; }
        [DisplayName(@"Sound")]
        public string Sound { get; set; }
        [DisplayName(@"note")]
        public string note { get; set; }
        [DisplayName(@"Spelling")]
        public string Spelling { get; set; }
        [DisplayName(@"Hiển Thị")]
        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
        [DisplayName(@"Nội dung 1")]
        public string temp1 { get; set; }
        [DisplayName(@"Nội dung 2")]
        public string temp2 { get; set; }
        [DisplayName(@"Nội dung 3")]
        public string temp3 { get; set; }
        [DisplayName(@"Nội dung 4")]
        public string temp4 { get; set; }
        [DisplayName(@"Nội dung 5")]
        public string temp5 { get; set; }
        [DisplayName(@"Start")]
        public string Star { get; set; }
        [DisplayName(@"Subject")]
        public int SubjectId { get; set; }
        public IEnumerable<SelectListItem> ListFlashCash { get; set; }
        public IEnumerable<SelectListItem> ListSubject { get; set; }
        [DisplayName(@"Sound File")]
        public HttpPostedFileBase SoundFile { get; set; }
    }
    public class FlashCashValidator : AbstractValidator<FlashCashFormModel>
    {
        public FlashCashValidator()
        {
            // RuleFor(x => x.Title).NotNull().WithMessage("fffffff");
            RuleFor(x => x.FlashCarhName).NotNull().WithMessage("FlashCashName không được để trống");
            //RuleFor(x => x.Description).NotNull().WithMessage("Mô Tả Không Được Để Trống");

        }
    }
}