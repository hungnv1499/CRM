using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation.Mvc;
using FluentValidation.Validators;
using FluentValidation;
using Outsourcing.Data.Models;
namespace Labixa.ViewModels
{
    public class OrderTour
    {
        public Product product { get; set; }
        //public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }

        //
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string Note { get; set; }
        public int Quantity { get; set; }
    }

}