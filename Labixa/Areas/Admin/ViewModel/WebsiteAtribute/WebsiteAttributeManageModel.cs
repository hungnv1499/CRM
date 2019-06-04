using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Outsourcing.Data.Models;

namespace Labixa.Areas.Admin.ViewModel.WebsiteAtribute
{
    public class WebsiteAttributeManageModel
    {

        public string Type { get; set; }
        public List<WebsiteAttribute> WebsiteAttributes { get; set; }
    }
}