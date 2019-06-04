using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Outsourcing.Data.Models;
using PagedList.Mvc;
namespace Labixa.ViewModels
{
    public class TourModels
    {
        public TourModels()
        {
        }
        public PagedList.IPagedList<Outsourcing.Data.Models.Product> ListProduct { get; set; }
    }
}