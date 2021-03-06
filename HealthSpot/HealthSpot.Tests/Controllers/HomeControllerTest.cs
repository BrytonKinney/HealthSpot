﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HealthSpot;
using HealthSpot.Controllers;
using HealthSpot.Context.Interfaces;

namespace HealthSpot.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IHealthSpotContext _hsContext;
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_hsContext);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(_hsContext);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(_hsContext);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
