using System;
using System.Collections.Generic;
using System.Text;

namespace ActedAlarmService
{
    public class ActedAlarm
    {
        public int Id { get; set; } = 0;
        public int Id_Alarm { get; set; } = 0;
        public int Id_Status { get; set; } = 0;
        public DateTime OutputDate { get; set; } = DateTime.MinValue;
        public DateTime InputDate { get; set; } = DateTime.MinValue;
        public DateTime RegisterDate { get; set; } = DateTime.MinValue;
        public string AlarmStatus { get; set; } = string.Empty;
        public string AlarmDescription { get; set; } = string.Empty;
        public string EquipmentDescription { get; set; } = string.Empty;
    }
}
