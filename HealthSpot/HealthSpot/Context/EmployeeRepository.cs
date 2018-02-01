using HealthSpot.Core;
using HealthSpot.Core.DomainObjects;
using HealthSpot.Core.NHibernateObjects;
using HealthSpot.Repository.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthSpot.Context
{
    public class EmployeeRepository
    {
        private static ISession _currentSession;
        public EmployeeRepository()
        {

        }
        public virtual Employee GetById(Type objType, int Id)
        {
            if (_currentSession == null || !_currentSession.IsOpen)
                _currentSession = NHibernateSessionManager.GetSession();
            return _currentSession.Get<Employee>(Id);
        }
    }
}