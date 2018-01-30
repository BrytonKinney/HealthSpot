using HealthSpot.Context.Interfaces;
using HealthSpot.Core;
using HealthSpot.Core.DomainObjects;
using HealthSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthSpot.Controllers
{
    public class HomeController : Controller
    {
        private IHealthSpotContext _hsContext;
        public HomeController(IHealthSpotContext healthContext)
        {
            _hsContext = healthContext;
        }
        public ActionResult Index()
        {
            ModelState.Clear();
            Employee emp = (Employee)_hsContext.Employees.GetById(typeof(Employee), 1);
            EmployeeModel empModel = AutoMapper.Mapper.Map<EmployeeModel>(emp);
            return View(empModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}