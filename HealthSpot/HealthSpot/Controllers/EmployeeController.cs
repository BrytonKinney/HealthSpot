using HealthSpot.Context.Interfaces;
using HealthSpot.Core;
using HealthSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace HealthSpot.Controllers
{
    public class EmployeeController : Controller
    {
        private IHealthSpotContext _hsContext;
        public EmployeeController(IHealthSpotContext healthSpotContext)
        {
            _hsContext = healthSpotContext;
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeLogin(LoginModel UserCredentials)
        {
            Employee emp = _hsContext.Employees.GetById(typeof(Employee), UserCredentials.Id);
            if (emp != null)
            {
                bool isTrue = Crypto.VerifyHashedPassword(emp.Password, UserCredentials.Password);
                if(isTrue)
                {
                    EmployeeModel empModel = AutoMapper.Mapper.Map<EmployeeModel>(emp);
                    empModel.IsAuthorized = isTrue;
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket("EmployeeAuthorizedLoginCredentials3adf3211dsfab@#$UYT(^*P|AZXCV!#$&%^*", true, 60 * 12);
                    var encryptedCookie = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookie));
                    Response.Cookies.Add(new HttpCookie("EmployeeId", emp.Id.ToString()));
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("~/Employee/Login");
        }
    }
}