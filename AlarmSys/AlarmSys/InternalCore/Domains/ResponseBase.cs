using AlarmSys.Core.Treaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSys
{
    public class ResponseBase
    {
        public bool Success { get; set; }
        public dynamic Data { get; set; }
        public int StatusCode { get; set; }
        public IReadOnlyCollection<Notification> Notifications { get; set; }
    }
}
