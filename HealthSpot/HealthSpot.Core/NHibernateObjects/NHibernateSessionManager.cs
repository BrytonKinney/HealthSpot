using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate;
using System.Configuration;
using HealthSpot.Core;
using HealthSpot.Core.DomainObjects;
using HealthSpot.Core.NHibernateObjects;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg.Db;
using NHibernate.SqlAzure;

namespace HealthSpot.Core
{
    public class NHibernateSessionManager : INHibernateSessionManager
    {
        private static ISession _session;
        private static ISessionFactory _sessionFactory;
        private static NHibernate.Cfg.Configuration _cfg;

        public ISession CurrentSession { get => GetSession(); set => CurrentSession = value; }

        public static ISessionFactory CreateSessionFactory()
        {
            if (_cfg == null)
            {
                _cfg = GetConfiguration();
            }
            _sessionFactory = _cfg.BuildSessionFactory();
            return _sessionFactory;
        }
        public static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                return _sessionFactory = CreateSessionFactory();
            return _sessionFactory;
        }
        /// <summary>
        /// Initializes NHibernate Configuration
        /// </summary>
        /// <returns></returns>
        public static NHibernate.Cfg.Configuration GetConfiguration()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2008.ConnectionString(System.Environment.GetEnvironmentVariable("DatabaseConnection")).Driver<SqlAzureClientDriver>())
                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Employee>())
                           .CurrentSessionContext("web")
                           .BuildConfiguration();
        }

        public static ISession GetSession()
        {
            if(_session == null || !_session.IsConnected || !_session.IsOpen)
            {
                _session = _sessionFactory.OpenSession();
            }
            return _session;
        }
    }
}
