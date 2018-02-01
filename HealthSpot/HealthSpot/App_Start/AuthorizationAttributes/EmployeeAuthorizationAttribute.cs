using HealthSpot.App_Start.AuthorizationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EmployeeAuthorizationAttribute), "Initialize")]
namespace HealthSpot.App_Start.AuthorizationAttributes
{
    public class EmployeeAuthorizationAttribute : AuthorizeAttribute
    {
        public EmployeeAuthorizationAttribute()
        {

        }
        public static void Initialize()
        {
            System.Collections.Specialized.NameValueCollection urls = new System.Collections.Specialized.NameValueCollection(2);
            urls.Add("DefaultUrl", "~/Home/Index");
            urls.Add("LoginUrl", "~/Employee/Login");
            FormsAuthentication.EnableFormsAuthentication(urls);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorizationCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authorizationCookie == null || string.IsNullOrEmpty(authorizationCookie.Value))
                return false;
            var authCookieVal = authorizationCookie.Value;
            FormsAuthenticationTicket ticketResult = FormsAuthentication.Decrypt(authCookieVal);
            if (ticketResult != null && !ticketResult.Expired)
                return true;
            return false;
        }
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