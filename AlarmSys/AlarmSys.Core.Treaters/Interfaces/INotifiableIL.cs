using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSys.Core.Treaters
{
    public interface INotifiableIL
    {
        IReadOnlyCollection<Notification> Notifications { get; }
    }
}
