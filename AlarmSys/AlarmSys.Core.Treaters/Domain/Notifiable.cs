using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSys.Core.Treaters.Domain
{
    public class Notifiable
    {
        public IReadOnlyCollection<Notification> Notifications { get; set; } = new List<Notification>();
        public int StatusCode { get; set; } = 0;
    }
}
