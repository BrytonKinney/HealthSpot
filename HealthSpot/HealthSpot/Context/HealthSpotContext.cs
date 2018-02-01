using HealthSpot.Context;
using HealthSpot.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using HealthSpot.Core.NHibernateObjects;
using HealthSpot.Core;
using HealthSpot.Repository.Interfaces;
using HealthSpot.Models;

namespace HealthSpot
{
    public class HealthSpotContext : IHealthSpotContext
    {
        public Employee GetLoggedInUser()
        {
            var employeeId = HttpContext.Current.Request.Cookies["EmployeeId"];
            if (employeeId == null || string.IsNullOrEmpty(employeeId.Value))
                return null;
            return NHibernateSessionManager.GetSession().Load<Employee>(Convert.ToInt32(employeeId.Value));
        }
        public EmployeeRepository Employees { get => new EmployeeRepository(); set => Employees = value; }
        public void SaveChanges<TEntity>(TEntity obj)
        {
            NHibernateSessionManager.GetSession().SaveOrUpdate(obj);
        }
    }
}