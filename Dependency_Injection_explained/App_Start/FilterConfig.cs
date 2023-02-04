using System.Web;
using System.Web.Mvc;

namespace Dependency_Injection_explained
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
