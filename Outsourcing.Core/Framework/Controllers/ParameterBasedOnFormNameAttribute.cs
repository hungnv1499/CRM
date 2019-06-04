using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Outsourcing.Core.Framework.Controllers
{
    /// <summary>
    /// If form name exists, then specified "actionParameterName" will be set to "true"
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ParameterBasedOnFormNameAttribute : FilterAttribute, IActionFilter
    {
        private readonly string _name;
        private readonly string _actionParameterName;

        public ParameterBasedOnFormNameAttribute(string name, string actionParameterName)
        {
            this._name = name;
            this._actionParameterName = actionParameterName;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var formValue = filterContext.RequestContext.HttpContext.Request.Form[_name];
            filterContext.ActionParameters[_actionParameterName] = !string.IsNullOrEmpty(formValue);
        }
    }
}
