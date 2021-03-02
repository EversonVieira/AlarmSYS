using AlarmSys.Core.Treaters.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSys.Core.Treaters
{
    public interface INotifiable
    {
        public Notifiable Notifiable { get; set; }
    }
}
