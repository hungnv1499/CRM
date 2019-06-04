using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Outsourcing.Data.Models;

namespace Labixa.Models
{
    public class HomeViewModel
    {
        public List<Product> HomePageProducts { get; set; }
        public List<Product> LongTourProducts { get; set; }
        public List<Blog> HomePageBlogs { get; set; }
        public List<Blog> HomePageNews { get; set; }
        public List<Blog> HomePageService { get; set; }
        public List<WebsiteAttribute> ListWebsiteAttribute { get; set; }
        public List<string> ListVideo { get; set; }
        public string HomeVideo { get; set; }
        public string Popup { get; set; }
    }

  
}