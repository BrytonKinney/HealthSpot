using HealthSpot.App_Start.AuthorizationAttributes;
using System.Web;
using System.Web.Mvc;

namespace HealthSpot
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
       //     filters.Add(new EmployeeAuthorizationAttribute());
        }
    }
}
