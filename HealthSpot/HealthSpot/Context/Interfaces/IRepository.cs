using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Data;

namespace HealthSpot.Repository.Interfaces
{
    public interface IRepository
    {
        object GetById(Type objType, object Id);
    }
}
