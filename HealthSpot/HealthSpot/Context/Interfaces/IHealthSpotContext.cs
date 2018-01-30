using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSpot.Context.Interfaces
{
    public interface IHealthSpotContext
    {
        EmployeeRepository Employees { get; set; }
    }
}
