﻿using HealthSpot.App_Start.AuthorizationAttributes;
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
    [EmployeeAuthorization]
    public class HomeController : Controller
    {
        private IHealthSpotContext _hsContext;
        public HomeController(IHealthSpotContext healthContext)
        {
            _hsContext = healthContext;
        }
        public ActionResult Index()
        {
            var emp = _hsContext.GetLoggedInUser();
            ModelState.Clear();
            var empModel = AutoMapper.Mapper.Map<EmployeeModel>(emp);
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