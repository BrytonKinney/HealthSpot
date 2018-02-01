using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace HealthSpot.Context.Interfaces
{
    public interface IHealthSpotContext
    {
        EmployeeRepository Employees { get; set; }
        void SaveChanges<TEntity>(TEntity obj);
    }
}
