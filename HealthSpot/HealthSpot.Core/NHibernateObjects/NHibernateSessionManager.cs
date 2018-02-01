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

namespace HealthSpot.Core
{
    /// <summary>
    /// Handles NHibernate sessions, session factories, and the initial configuration
    /// </summary>
    public class NHibernateSessionManager : INHibernateSessionManager
    {
        private static ISession _session;
        /// <summary>
        /// Session Factory used to open new sessions and dispose of them.
        /// </summary>
        private static ISessionFactory _sessionFactory;
        private static NHibernate.Cfg.Configuration _cfg;

        /// <summary>
        /// Returns current session. If the session does not exist, it will open a new one.
        /// </summary>
        public ISession CurrentSession { get => GetSession(); set => CurrentSession = value; }

        /// <summary>
        /// Builds the session factory.
        /// </summary>
        /// <returns>ISessionFactory</returns>
        public static ISessionFactory CreateSessionFactory()
        {
            if (_cfg == null)
            {
                _cfg = GetConfiguration();
            }
            _sessionFactory = _cfg.BuildSessionFactory();
            return _sessionFactory;
        }

        /// <summary>
        /// Returns the current session factory. If one does not exist, it creates a new one. It is preferrable to use this if you are attempting to get the session factory,
        /// as if an instance exists, it will return that first, preventing the expensive construction of a new one.
        /// </summary>
        /// <returns>ISessionFactory, current or new.</returns>
        public static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                return _sessionFactory = CreateSessionFactory();
            return _sessionFactory;
        }
        /// <summary>
        /// Initializes NHibernate Configuration.
        /// </summary>
        /// <returns></returns>
        public static NHibernate.Cfg.Configuration GetConfiguration()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration
                                        .MsSql2008
                                        .ConnectionString(System.Environment.GetEnvironmentVariable("DatabaseConnection")))
                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Employee>())
                           .CurrentSessionContext("web")
                           .BuildConfiguration();
        }

        /// <summary>
        /// Gets the existing session, or creates a new one.
        /// </summary>
        /// <returns>ISession, new or existing.</returns>
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
