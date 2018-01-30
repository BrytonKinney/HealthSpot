using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSpot.Core.NHibernateObjects
{
    public interface INHibernateSessionManager
    {
        ISession CurrentSession { get; set; }
    }
}
