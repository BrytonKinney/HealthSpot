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
            Table("EMPLOYEE");
            Id(m => m.Id, "Id");
            Map(m => m.FirstName, "First_NME");
            Map(m => m.LastName, "Last_NME");
            Map(m => m.BirthDate, "Birth_DTE");
            Map(m => m.JobTitle, "JobTitle_DSC");
        }
    }
}
