using System.Web;
using System.Web.Mvc;

namespace PostSharp_Conveyor_Example_Timesheet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
