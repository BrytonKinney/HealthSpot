using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HealthSpot.Core;
using Ninject.Modules;
using HealthSpot.Context.Interfaces;
using HealthSpot.Repository.Interfaces;
using Ninject;
using System.Reflection;
using Ninject.Web.Common;
using HealthSpot.Context;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using HealthSpot;
using NHibernate;
using HealthSpot.App_Start;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", Watch = true)]

namespace HealthSpot
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
            NHibernateSessionManager.CreateSessionFactory();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var session = NHibernateSessionManager.GetSession();
            NHibernate.Context.CurrentSessionContext.Bind(session);
            session.BeginTransaction();
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = NHibernateSessionManager.GetSession();
            if (session.Transaction != null && session.Transaction.IsActive)
                session.Transaction.Commit();
            NHibernate.Context.CurrentSessionContext.Unbind(NHibernateSessionManager.GetSessionFactory());
            session.Dispose();
        }
    }
}
