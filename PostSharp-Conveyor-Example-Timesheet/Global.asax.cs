using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Serilog;
using Serilog;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

// Apply logging to all methods and properties:
[assembly: Log]

namespace PostSharp_Conveyor_Example_Timesheet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Configure Serilog to send logging events to a file:
            const string template = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Indent:l}{Message}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.File(@"C:\Logs\log.log", outputTemplate: template)
                            .CreateLogger();
            
            // Configure PostSharp to send automatic logging to Serilog:
            LoggingServices.DefaultBackend = new SerilogLoggingBackend(Log.Logger);
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
