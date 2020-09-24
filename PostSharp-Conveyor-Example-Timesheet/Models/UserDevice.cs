using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostSharp_Conveyor_Example_Timesheet.Models
{
    public class UserDevice
    {
        public enum DeviceFormat
        {
            Mobile,
            Desktop
        }

        public DeviceFormat Format { get; set; }

        public UserDevice(string useragent)
        {
            DetermineDeviceFormat(useragent);
        }

        void DetermineDeviceFormat(string useragent)
        {
            //This doesn't actually support iOS 13 which uses the same user agent as desktop.
            if(useragent.Contains("android") || useragent.Contains("iphone") || useragent.Contains("ipad"))
            {
                Format = DeviceFormat.Mobile;
            } else
            {
                Format = DeviceFormat.Desktop;
            }
        }
    }
}