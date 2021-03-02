using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmService
{
    public class AlarmFilter:Alarm
    {
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
    }
}
