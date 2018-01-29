using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using HealthSpot.Core.DomainObjects;

namespace HealthSpot.Core.NHibernate.Mappings
{
    class EmployeMapping : ClassMap<Employee>
    {
        public EmployeMapping()
        {

        }
    }
}
