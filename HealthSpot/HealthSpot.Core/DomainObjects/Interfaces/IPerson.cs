using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSpot.Core.DomainObjects
{
    interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
    }
}
