using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace HealthSpot.App_Start.AuthorizationAttributes
{
    public class EmployeeAuthorizationAttribute : AuthorizeAttribute
    {
        public EmployeeAuthorizationAttribute()
        {

        }
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    IPrincipal user = httpContext.User;
        //    return user.Identity.IsAuthenticated;
        //}
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult() { ViewName = "~/Views/Employee/Login.cshtml" };
        }
    }
}