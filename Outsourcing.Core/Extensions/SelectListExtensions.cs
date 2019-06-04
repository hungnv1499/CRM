using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Outsourcing.Core;
using System.ComponentModel;
using Outsourcing.Data.Models;


namespace Outsourcing.Core.Extensions
{
    public static class SelectListExtensions
    {
        //public static IEnumerable<SelectListItem> ToSelectListItems(
        //      this IEnumerable<ApplicationUser> users, string selectedId)
        //{
        //    return

        //        users.OrderBy(user => user.Id)
        //              .Select(user =>
        //                  new SelectListItem
        //                  {
        //                      Selected = (user.Id == selectedId),
        //                      Text = user.DisplayName,
        //                      Value = user.Id.ToString()
        //                  });
        //}

        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<BlogCategory> BlogCategory, int selectedId)
        {
            return

                BlogCategory.OrderBy(f => f.CategoryParentId)
                      .Select(f =>
                          new SelectListItem
                          {
                              Selected = (f.Id == selectedId),
                              Text = f.Name,
                              Value = f.Id.ToString()
                          });
        }


        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<Product> product, int selectedId)
        {
            return

                product.OrderBy(f => f.Id)
                      .Select(f =>
                          new SelectListItem
                          {
                              Selected = (f.Id == selectedId),
                              Text = f.Name,
                              Value = f.Id.ToString()
                          });
        }
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<AspNetUser> user, string selectedId)
        {
            return

                user.OrderBy(f => f.Id)
                      .Select(f =>
                          new SelectListItem
                          {
                              Selected = (f.Id == selectedId),
                              Text = f.FirstName + f.LastName,
                              Value = f.Id.ToString()
                          });
        }
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<ProductCategory> productCategories, int selectedId)
        {
            return

                productCategories.OrderBy(f => f.Id)
                      .Select(f =>
                          new SelectListItem
                          {
                              Selected = (f.Id == selectedId),
                              Text = f.Name,
                              Value = f.Id.ToString()
                          });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(
      this IEnumerable<AspNetRole> Role, string selectedId)
        {
            return

                Role.OrderBy(f => f.Id)
                      .Select(f =>
                          new SelectListItem
                          {
                              Selected = (f.Id == selectedId),
                              Text = f.Name,
                              Value = f.Id.ToString()
                          });
        }
       

    }
}
