using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PostSharp_Conveyor_Example_Timesheet.Models
{
    public class ClockInModel
    {


        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        public string Location { get; set; }
        [DisplayName("In Time")]
        public DateTime InTime { get; set; }
        [DisplayName("Out Time")]
        public DateTime OutTime { get; set; }

    }
}