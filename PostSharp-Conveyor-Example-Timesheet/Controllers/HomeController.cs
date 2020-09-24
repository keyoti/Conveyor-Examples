using PostSharp_Conveyor_Example_Timesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostSharp_Conveyor_Example_Timesheet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ClockIn()
        {
            UserDevice userDevice = new UserDevice(Request.UserAgent);
            ViewBag.Message = "Clock In";
            ViewBag.DeviceFormat = userDevice.Format;

            return View();
        }
    }
}