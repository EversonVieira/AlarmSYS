using AlarmSys.Core.Treaters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActedAlarmService
{
    public class ActedAlarmIL : INotifiableIL
    {
        private List<Notification> _Notifications = new List<Notification>();
        public IReadOnlyCollection<Notification> Notifications => _Notifications;

        public bool ValidateInsert(ActedAlarm actedAlarm)
        {
            if (actedAlarm.Id != 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = actedAlarm.Id,
                    message = "Id can't be different than 0."
                });
            }

            if (actedAlarm.Id_Alarm == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Alarm",
                    value = actedAlarm.Id_Alarm,
                    message = "Choose an Alarm to insert this ActedAlarmIL."
                });
            }

            if (actedAlarm.Id_Status == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Status",
                    value = actedAlarm.Id_Status,
                    message = "ActedAlarmIL can't be inserted without an Status."
                });
            }

            if (actedAlarm.InputDate == DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "InputDate",
                    value = actedAlarm.Id,
                    message = "InputDate should be informed"
                });
            }

            if (actedAlarm.RegisterDate != DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "RegisterDate",
                    value = actedAlarm.RegisterDate,
                    message = "Register Date should be inserted by DataBase."
                });
            }


            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateUpdate(ActedAlarm actedAlarm)
        {
            if (actedAlarm.Id == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = actedAlarm.Id,
                    message = "Id can't be 0."
                });
            }

            if (actedAlarm.Id_Alarm == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Classification",
                    value = actedAlarm.Id_Alarm,
                    message = "Choose an Alarm to insert this ActedAlarmIL."
                });
            }

            if (actedAlarm.Id_Status == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Equipment",
                    value = actedAlarm.Id_Status,
                    message = "ActedAlarmIL can't be inserted without an Status."
                });
            }

            if (actedAlarm.InputDate == DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = actedAlarm.Id,
                    message = "InputDate should be informed"
                });
            }

            if (actedAlarm.RegisterDate != DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "RegisterDate",
                    value = actedAlarm.RegisterDate,
                    message = "Register Date should be inserted by DataBase."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateDelete(ActedAlarm actedAlarm)
        {
            if (actedAlarm.Id == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = actedAlarm.Id,
                    message = "Id can't be 0."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateSelect(ActedAlarm actedAlarm)
        {
            if (actedAlarm.Id == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = actedAlarm.Id,
                    message = "Id can't be 0."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateFilter(ActedAlarmFilter actedAlarmFilter)
        {
            if (actedAlarmFilter.Id != 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = actedAlarmFilter.Id,
                    message = "Id can't be different than 0."
                });
            }
            if (actedAlarmFilter.StartDate == DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "StartDate",
                    value = actedAlarmFilter.StartDate,
                    message = "StartDate need to be defined with a valid value."
                });
            }
            if (actedAlarmFilter.StartDate > actedAlarmFilter.EndDate)
            {
                this._Notifications.Add(new Notification
                {
                    field = "StartDate",
                    value = actedAlarmFilter.StartDate,
                    message = "StartDate can't be higher than EndDate."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
    }
}
