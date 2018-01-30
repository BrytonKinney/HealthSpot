using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using HealthSpot.Core.DomainObjects;

namespace HealthSpot.Core
{
    class EmployeeMapping : ClassMap<Employee>
    {
        public EmployeeMapping()
        {
            Table("employee");
            Id(m => m.Id, "Id");
            Map(m => m.FirstName, "FirstName");
            Map(m => m.LastName, "LastName");
            Map(m => m.BirthDate, "BirthDate");
            Map(m => m.JobTitle, "JobTitle");
        }
    }
}
