using AlarmSys.Core.Treaters;
using AlarmSys.Core.Treaters.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace AlarmService
{
    internal class AlarmIL:INotifiableIL
    {
        private List<Notification> _Notifications = new List<Notification>();
        public IReadOnlyCollection<Notification> Notifications => _Notifications;

        public bool ValidateInsert(Alarm alarm)
        {
            if (alarm.Id != 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = alarm.Id,
                    message = "Id can't be different than 0."
                });
            }

            if (alarm.Id_Classification == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Classification",
                    value = alarm.Id_Classification,
                    message = "Choose an Classification to insert this Alarm."
                });
            }

            if (alarm.Id_Equipment == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Equipment",
                    value = alarm.Id_Equipment,
                    message = "Alarm can't be inserted without an equipment."
                });
            }

            if (string.IsNullOrEmpty(alarm.Description))
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = alarm.Id,
                    message = "Description should be informed."
                });
            }
            
            if (alarm.RegisterDate != DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "RegisterDate",
                    value = alarm.RegisterDate,
                    message = "Register Date should be inserted by DataBase."
                });
            }
            

            return _Notifications.Count > 0 ? false:true;
        }
        public bool ValidateUpdate(Alarm alarm)
        {
            if (alarm.Id == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = alarm.Id,
                    message = "Id can't be 0."
                });
            }

            if (alarm.Id_Classification == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Classification",
                    value = alarm.Id_Classification,
                    message = "Should choose an Classification to update this register."
                });
            }

            if (alarm.Id_Equipment == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Equipment",
                    value = alarm.Id_Equipment,
                    message = "Should choose an Equipment to update this register."
                });
            }

            if (string.IsNullOrEmpty(alarm.Description))
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = alarm.Id,
                    message = "Description should be informed."
                });
            }

            if (alarm.RegisterDate != DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "RegisterDate",
                    value = alarm.RegisterDate,
                    message = "Register date should be inserted by DataBase."
                });
            }
            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateDelete(Alarm alarm)
        {
            if (alarm.Id == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = alarm.Id,
                    message = "Id can't be 0."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateSelect(Alarm alarm)
        {
            if (alarm.Id == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = alarm.Id,
                    message = "Id can't be 0."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateFilter(AlarmFilter alarmFilter)
        {
            if (alarmFilter.Id != 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = alarmFilter.Id,
                    message = "Id can't be different than 0."
                });
            }
            if (alarmFilter.StartDate == DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "StartDate",
                    value = alarmFilter.StartDate,
                    message = "StartDate need to be defined with a valid value."
                });
            }
            if (alarmFilter.StartDate > alarmFilter.EndDate)
            {
                this._Notifications.Add(new Notification
                {
                    field = "StartDate",
                    value = alarmFilter.StartDate,
                    message = "StartDate can't be higher than EndDate."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
    }
}
