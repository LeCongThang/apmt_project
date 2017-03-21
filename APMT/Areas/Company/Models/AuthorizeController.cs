using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace APMT.Areas.Company.Models
{
    public class AuthorizeController:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string[] listpermission = { "Project-Create" };
            string actionName =filterContext.ActionDescriptor.ControllerDescriptor.ControllerName+"-"+
                filterContext.ActionDescriptor.ActionName;
            if (listpermission.Contains(actionName))
            {
                filterContext.Result = new RedirectResult("~/Company/Project/NotificationAuthorize");
            }

        }
    }
}