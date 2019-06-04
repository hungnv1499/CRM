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
    public class ProductRelationFormModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName(@"Sản Phẩm")]
        public int ProductId { get; set; }

        [DisplayName(@"Sản Phẩm Liên Quan")]
        public int? ProductId2 { get; set; }

        [DisplayName(@"Hiển Thị")]
        public bool isAvailable { get; set; }

        public virtual Product ProductRelationship { get; set; }
        public virtual Product ProductRelated { get; set; }

       
    }
}