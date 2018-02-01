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
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeLogin(LoginModel UserCredentials)
        {
            Employee emp = _hsContext.Employees.GetById(typeof(Employee), UserCredentials.Id);
            if (emp != null)
            {
                //if (string.IsNullOrEmpty(emp.Password))
                //{
                //    string newPassword = Crypto.HashPassword(UserCredentials.Password);
                //    emp.Password = newPassword;
                //    _hsContext.SaveChanges(emp);
                //}
                bool isTrue = Crypto.VerifyHashedPassword(emp.Password, UserCredentials.Password);
                if(isTrue)
                {
                    EmployeeModel empModel = AutoMapper.Mapper.Map<EmployeeModel>(emp);
                    empModel.IsAuthorized = isTrue;
                    FormsAuthentication.SetAuthCookie(empModel.Id.ToString(), true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}