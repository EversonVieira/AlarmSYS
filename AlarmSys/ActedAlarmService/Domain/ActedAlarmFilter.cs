using System;
using System.Collections.Generic;
using System.Text;

namespace ActedAlarmService
{
    public class ActedAlarmFilter:ActedAlarm
    {
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
    }
}
