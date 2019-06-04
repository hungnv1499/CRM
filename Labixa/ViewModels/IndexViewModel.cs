using Outsourcing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labixa.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> productHome { get; set; }

        public IEnumerable<Product> productHomeV2 { get; set; }

        public IEnumerable<WebsiteAttribute> imageHome1 { get; set; }
        public IEnumerable<WebsiteAttribute> imageHome2 { get; set; }
    }
}