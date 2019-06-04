using System.Web.Mvc;
using Outsourcing.Core.Helpers;

namespace Outsourcing.Core.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static UserHtmlHelper User(this HtmlHelper html)
        {
            return new UserHtmlHelper(html, new UrlHelper(html.ViewContext.RequestContext));
        }
    }
}