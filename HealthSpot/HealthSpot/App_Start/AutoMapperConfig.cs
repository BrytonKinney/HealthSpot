using HealthSpot.Core;
using HealthSpot.Core.DomainObjects;
using HealthSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthSpot.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeModel>();
                cfg.CreateMap<EmployeeModel, Employee>();
            });
        }
    }
}