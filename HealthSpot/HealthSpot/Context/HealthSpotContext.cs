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

namespace HealthSpot
{
    public class HealthSpotContext : IHealthSpotContext
    {
        public EmployeeRepository Employees { get => new EmployeeRepository(); set => Employees = value; }
        public void SaveChanges<TEntity>(TEntity obj)
        {
            NHibernateSessionManager.GetSession().SaveOrUpdate(obj);
        }
    }
}