using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSys.Core.Treaters
{
    public class Notification
    {
        public string field { get; set; } = string.Empty;
        public dynamic value { get; set; } = null;
        public string message { get; set; } = string.Empty;
    }
}
