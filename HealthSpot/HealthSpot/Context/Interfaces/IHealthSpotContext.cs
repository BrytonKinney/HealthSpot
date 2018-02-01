using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HealthSpot.Models;
using HealthSpot.Core;

namespace HealthSpot.Context.Interfaces
{
    public interface IHealthSpotContext
    {
        Employee GetLoggedInUser();
        EmployeeRepository Employees { get; set; }
        void SaveChanges<TEntity>(TEntity obj);
    }
}
